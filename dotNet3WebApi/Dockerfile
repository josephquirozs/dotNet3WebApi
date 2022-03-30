FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal
WORKDIR /app
COPY bin/Release/netcoreapp3.1/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "dotNet3WebApi.dll"]