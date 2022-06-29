pipeline {
  agent none
  stages {
    stage('Restore packages') {
      agent {
        docker {
          image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
        }
      }
      steps {
        dotnetRestore()
      }
    }

    stage('check docker') {
      agent any
      steps {
        sh 'docker --help'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
