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
        sh 'dotnet publish'
      }
    }

    // stage('build image') {
    //   agent any
    //   steps {
    //     sh 'ls -la'
    //   }
    // }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
