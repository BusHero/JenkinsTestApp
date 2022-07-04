pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore'
        sh 'dotnet build -c Release'
        sh 'dotnet test -c Release'
        sh 'dotnet publish -c Release'
        sh "docker build -t jenkinstestapp:$BUILD_NUMBER ./JenkinsTestApp/"
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = true
  }
}
