pipeline {
  agent any
  stages {
    stage('Compile') {
      steps {
        withDotNet(sdk: '6.0') {
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