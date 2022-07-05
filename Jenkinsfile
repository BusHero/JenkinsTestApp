pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore --verbosoity Quiet'
        sh 'dotnet build --configuration Release --no-restore --nologo'
        sh 'dotnet test --configuration Release --nologo --no-restore --verbosity Quiet --logger trx'
        
        mstest testResultsFile:"**/*.trx", keepLongStdio: true
        
        sh 'dotnet publish --configuration Release --verbosity Quit --no-restore'
        sh "docker build --quiet --tag jenkinstestapp:$BUILD_NUMBER ./JenkinsTestApp/"
      }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = true
  }
}
