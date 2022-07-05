pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore --verbosity Quiet'
        sh 'dotnet build --verbosity Quiet --configuration Release --no-restore --nologo'
        sh 'dotnet test --configuration Release --nologo --no-restore --verbosity Quiet --logger trx'
        sh 'dotnet publish --configuration Release --verbosity Quiet --no-restore'
        sh "docker build --quiet --tag jenkinstestapp:$BUILD_NUMBER ./JenkinsTestApp/"
      }
    }
    stage('Sanity check') {
        steps {
            input "Does the staging environment look ok?"
        }
    }
  }
  environment {
    DOTNET_CLI_HOME = '/tmp'
    DOTNET_CLI_TELEMETRY_OPTOUT = true
  }
  post {
    always {
        mstest testResultsFile:"**/*.trx", keepLongStdio: true
    }
  }
}
