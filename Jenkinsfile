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

  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
}