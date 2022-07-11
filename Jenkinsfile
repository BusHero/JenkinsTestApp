pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh './build.sh compile --no-logo --verbosity Quiet  --configuration Release'
        sh './build.sh test --no-logo --verbosity Quiet  --configuration Release'
        sh './build.sh publish --no-logo --verbosity Quiet  --configuration Release'
        sh './build.sh build-app-image --no-logo --verbosity Quiet '
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
                            sh './build.sh push-app-image --no-logo --verbosity Quiet --tag $BUILD_NUMBER --DockerRegistryKey $REGISTRY_KEY'
                        }
                    }
                    stage ('Run smoke tests') {
                        steps {
                            sh './build.sh run-app-image --no-logo --verbosity Quiet --PublishPort 8081 --Tag $BUILD_NUMBER'
                            sh './build.sh run-smoke-test --no-logo --verbosity Quiet --Tag $BUILD_NUMBER'
                        }
                        post {
                            always {
                                sh './build.sh stop-app-container --no-logo --verbosity Quiet --tag $BUILD_NUMBER'
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
                                sh './scripts/jenkins/stop-docker-container.sh "jenkinstestapp_latest"'
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
}
