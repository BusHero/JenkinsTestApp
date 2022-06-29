pipeline {
  stages {
    stage('Restore packages') {
      agent {
        docker {
          image 'mcr.microsoft.com/dotnet/sdk:6.0.301-1-alpine3.16-amd64'
        }
      }
      steps {
        dotnetRestore()
      }
    }

    stage('check docker') {
      agent any
      steps {
        sh 'docker --help'
      }
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
