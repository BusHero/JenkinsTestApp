  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY bin/Release/net6.0/debug/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "JenkinsTestApp.dll"]