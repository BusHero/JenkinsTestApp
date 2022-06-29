pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    }
  }
  stages {
    stage('Restore packages') {
      steps {
        dotnetRestore()
      }
    }

    stage('Clean') {
      steps {
        dotnetClean()
      }
    }

    stage('Build') {
      steps {
        dotnetBuild()
      }
    }

    stage('Publish') {
      steps {
        dotnetPublish()
      }
    }
    stage('Build Docker Container') {
        agent any {
            steps {
                sh docker --help
            }
        }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}