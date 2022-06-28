pipeline {
  agent any
  stages {
    stage('Clean Workspace') {
      steps {
        cleanWs()
      }
    }

    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/BusHero/JenkinsTestApp.git', branch: 'master', credentialsId: 'test')
      }
    }

    stage('Restore Packages') {
      steps {
        sh 'dotnet restore'
      }
    }

  }
}