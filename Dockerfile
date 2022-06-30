  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY JenkinsTestApp/bin/Debug/net6.0/publish/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "JenkinsTestApp.dll"]