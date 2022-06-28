pipeline {
  agent any
  stages {
    stage('Compile') {
      steps {
        withDotNet() {
          dotnetBuild()
        }

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