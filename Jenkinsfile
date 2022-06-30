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

    stage('Publish') {
      agent {
        docker {
          image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
        }
      }
      steps {
        dotnetPublish()
      }
    }

    stage('build image') {
      agent any
      steps {
        sh 'ls ./JenkinsTestApp/bin/Debug/net6.0/publish/'
        // sh 'docker build .'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
