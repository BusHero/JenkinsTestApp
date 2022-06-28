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

    stage('Install dotnet') {
      steps {
        sh '''curl -fSL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz \\
    && dotnet_sha512=\'2f434ea4860ee637e9cf19991a80e1febb1105531dd96b4fbc728d538ca0ab202a0bdff128fd13b269fac3ba3bc9d5f9c49039a6e0d7d32751e8a2bb6d790446\' \\
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \\
    && mkdir -p /usr/share/dotnet \\
    && tar -oxzf dotnet.tar.gz -C /usr/share/dotnet ./packs ./sdk ./sdk-manifests ./templates ./LICENSE.txt ./ThirdPartyNotices.txt \\
    && rm dotnet.tar.gz \\'''
      }
    }

  }
}