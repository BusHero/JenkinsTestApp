pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:6.0'
    }

  }
  stages {
    stage('Check dotnet installation') {
      steps {
        sh 'dotnet help'
      }
    }

  }
}