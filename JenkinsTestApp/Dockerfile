FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY bin/Release/net6.0/publish/ App/
WORKDIR /App
LABEL org.opencontainers.image.description "Some description here and there "
ENTRYPOINT ["dotnet", "JenkinsTestApp.dll"]
