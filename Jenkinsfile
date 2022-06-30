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
        sh 'docker build -t jenkinstestapp ./JenkinsTestApp/'
        sh 'docker push localhost:5000/jenkinstestapp'
      }
    }

    // stage('build image') {
    //   steps {
    //   }
    // }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
