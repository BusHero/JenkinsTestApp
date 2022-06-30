pipeline {
  agent any
  stages {
    // stage('Restore packages') {
    //   agent {
    //     docker {
    //       image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    //     }
    //   }
    //   steps {
    //     dotnetRestore()
    //   }
    // }

    // stage('Build') {
    //   agent {
    //     docker {
    //       image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    //     }
    //   }
    //   steps {
    //     dotnetBuild()
    //   }
    // }

    stage('Publish') {
      steps {
        sh 'dotnet restore'
        sh 'dotnet build -c Release'
        sh 'dotnet publish -c Release'
        sh 'docker build -t jenkinstestapp:latest ./JenkinsTestApp/'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
