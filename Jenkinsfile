pipeline {
  agent {
    docker {
      image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
    }

  }
  stages {
    stage('Restore packages') {
      parallel {
        stage('Restore packages') {
          steps {
            dotnetRestore()
          }
        }

        stage('') {
          steps {
            sh 'docker --help'
          }
        }

      }
    }

    stage('Clean') {
      steps {
        dotnetClean()
      }
    }

    stage('Build') {
      steps {
        dotnetBuild()
      }
    }

    stage('Publish') {
      steps {
        dotnetPublish()
      }
    }

    stage('Build Docker Container') {
    }

  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
  }
  post {
    always {
      archiveArtifacts(artifacts: 'JenkinsTestApp/bin/Debug/net6.0/publish/', fingerprint: true)
    }

  }
}