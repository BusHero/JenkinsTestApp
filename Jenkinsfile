pipeline {
  agent none
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

    // stage('Publish') {
    //   agent {
    //     docker {
    //       image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    //       args '-v $Home/publish:$Home/publish'
    //     }
    //   }
    //   steps {
    //     sh 'dotnet publish -o ./publish'
    //   }
    // }

    stage('build image') {
      agent any
      steps {
        sh 'docker build .'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
