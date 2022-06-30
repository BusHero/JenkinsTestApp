pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore'
        sh 'dotnet build -c Release'
        sh 'dotnet publish -c Release'
        sh 'docker build -t jenkinstestapp:${currentBuild.number} ./JenkinsTestApp/'
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = true
  }
}
