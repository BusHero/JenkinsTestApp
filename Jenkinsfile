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
    stage('Check docker image') {
        steps {
            sh """
               docker run --rm --detach --publish 8081:80 --name "jenkinstestapp$BUILD_NUMBER" jenkinstestapp:$BUILD_NUMBER
               sleep 5
               curl -Is localhost:8081 --head --fail --silent
               docker stop "jenkinstestapp$BUILD_NUMBER"
               """
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
