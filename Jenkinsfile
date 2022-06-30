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

    stage('Build') {
      agent {
        docker {
          image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
        }
      }
      steps {
        dotnetBuild()
      }
    }

    stage('Pack') {
      agent {
        docker {
          image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
        }
      }
      steps {
        dotnetPack()
      }
    }

    stage('build image') {
      agent any
      steps {
        sh 'docker build ./JenkinsTestApp'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
