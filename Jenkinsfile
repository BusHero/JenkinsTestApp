pipeline {
  agent any
  stages {
    stage('Compile') {
      steps {
        echo 'Hello, World!'
        pwd(tmp: true)
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