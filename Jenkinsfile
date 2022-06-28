pipeline {
  agent any
  stages {
    stage('build') {
      parallel {
        stage('build') {
          steps {
            echo 'build stage'
          }
        }

        stage('Some other name') {
          steps {
            echo 'parallel'
          }
        }

      }
    }

  }
}