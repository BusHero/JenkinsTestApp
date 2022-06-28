pipeline {
  agent any
  stages {
    stage('Compile') {
      steps {
        sh 'dotnet build'
      }
    }

    stage('Test') {
      steps {
        echo 'Another message'
      }
    }

    stage('Deploy') {
      steps {
        echo 'Deploy'
      }
    }

  }
}