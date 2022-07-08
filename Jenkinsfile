pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore --verbosity Quiet'
        sh 'dotnet build --verbosity Quiet --configuration Release --no-restore --nologo'
        sh 'dotnet test --configuration Release --nologo --no-restore --verbosity Quiet --logger trx'
        sh 'dotnet publish --configuration Release --nologo --verbosity Quiet --no-restore'
        sh "docker build --quiet --tag jenkinstestapp ./JenkinsTestApp/"
      }
    }
    stage ('Push Images') {
        environment {
          REGISTRY_KEY = credentials('GitHub_Registry_Key')
        }
        parallel {
            stage('Push tagged image') {
                stages {
                    stage('Push') {
                        steps {
                            sh 'dotnet run --project ./build/_build.csproj -- login-jenkins --DockerRegistryKey $REGISTRY_KEY'
                            // sh './build.sh login-jenkins --DockerRegistryKey $REGISTRY_KEY'
                            sh 'docker tag jenkinstestapp ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER'
                            sh 'docker push ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER'
                        }
                    }
                    stage ('Run smoke tests') {
                        steps {
                            sh 'docker run --rm --detach --publish 8081:80 --network jenkins --network-alias jenkinstestapp --name "jenkinstestapp_$BUILD_NUMBER" "ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER"'
                            sh 'sleep 5'
                            sh 'curl -Is jenkinstestapp:80 --head' 
                        }
                        post {
                            always {
                                sh '''
                                    if docker ps --format "{{.Names}}" | grep -q "jenkinstestapp_$BUILD_NUMBER$"
                                    then
                                        docker stop "jenkinstestapp_$BUILD_NUMBER"
                                    fi
                                '''
                            }
                        }
                    }
                }
            }
            stage('Push latest image') {
                stages {
                    stage('Push') {
                        steps {
                            sh 'echo $REGISTRY_KEY | docker login ghcr.io -u BusHero --password-stdin'
                            sh 'docker tag jenkinstestapp ghcr.io/bushero/jenkinstestapp:latest'
                            sh 'docker push ghcr.io/bushero/jenkinstestapp:latest'
                        }
                    }
                    stage ('Run smoke tests') {
                        steps {
                            sh 'docker run --rm --detach --publish 8082:80 --network jenkins --network-alias jenkinstestapp_latest --name "jenkinstestapp_latest" "ghcr.io/bushero/jenkinstestapp:latest"'
                            sh 'sleep 5'
                            sh 'curl -Is jenkinstestapp_latest:80 --head' 
                        }
                        post {
                            always {
                                sh '''
                                    if docker ps --format "{{.Names}}" | grep -q "jenkinstestapp_latest$"
                                    then
                                        docker stop jenkinstestapp_latest
                                    fi
                                '''
                            }
                        }
                    }
                }
            }
        }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = true
  }
  post {
    always {
        mstest testResultsFile:"**/*.trx", keepLongStdio: true
    }
  }
}
