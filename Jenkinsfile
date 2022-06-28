pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    }
  }
  stages {
    stage('Check dotnet installation') {
      steps {
        sh 'dotnet help'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}