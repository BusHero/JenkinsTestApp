pipeline {
  agent any
  stages {
    stage('Commit') {
      steps {
        sh 'dotnet restore --verbosity Quiet'
        sh 'dotnet build --verbosity Quiet --configuration Release --no-restore --nologo'
        sh 'dotnet test --configuration Release --nologo --no-restore --verbosity Quiet --logger trx'
        sh 'dotnet publish --configuration Release --nologo --verbosity Quiet --no-restore'
        sh "docker build --quiet --tag jenkinstestapp ./JenkinsTestApp/"
      }
    }
    stage ('Push image') {
        environment {
          REGISTRY_KEY = credentials('GitHub_Registry_Key')
        }
        steps {
            script {
                sh 'echo $REGISTRY_KEY | docker login ghcr.io -u BusHero --password-stdin'
                sh 'docker tag jenkinstestapp ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER'
                sh 'docker push ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER'
            }
        }
    }
    stage('Check docker image') {
        steps {
            sh """
               docker run --rm --detach --publish 8081:80 --network jenkins --network-alias jenkinstestapp --name "jenkinstestapp$BUILD_NUMBER" "ghcr.io/bushero/jenkinstestapp:$BUILD_NUMBER"
               curl -Is jenkinstestapp:80 --head 
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
