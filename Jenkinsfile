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
                    stage('Push tagged image') {
                        steps {
                            sh './build.sh push-app-image --no-logo --verbosity Quiet --tag $BUILD_NUMBER --DockerRegistryKey $REGISTRY_KEY'
                        }
                    }
                    stage ('Run smoke tests tagged image') {
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
                    stage('Push latest image') {
                        steps {
                            sh './build.sh push-app-image --no-logo --verbosity Quiet --tag latest --DockerRegistryKey $REGISTRY_KEY'
                        }
                    }
                    stage ('Run smoke tests latest image') {
                        steps {
                            sh './build.sh run-app-image --no-logo --verbosity Quiet --PublishPort 8082 --Tag latest'
                            sh './build.sh run-smoke-test --no-logo --verbosity Quiet --Tag latest'
                        }
                        post {
                            always {
                                sh './build.sh stop-app-container --no-logo --verbosity Quiet --tag latest'
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
