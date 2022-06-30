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
        sh 'ls /var/jenkins_home/workspace/JenkinsTestApp_master/JenkinsTestApp/bin/Debug/net6.0/publish/'
        // sh 'docker build .'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}
