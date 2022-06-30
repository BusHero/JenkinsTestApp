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
        // sh 'dotnet publish'
        // sh 'docker build -t jenkinstestapp:latest ./JenkinsTestApp/'
        // sh 'docker push registry:5000/jenkinstestapp:latest'
        sh 'docker pull ubuntu'
        sh 'docker tag ubuntu 172.19.0.3:5000/ubuntu'
        sh 'docker push 172.19.0.3:5000/ubuntu'
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
