FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal
COPY bin/Release/netcoreapp3.1/publish/ app/
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "dotNet3WebApi.dll"]

# dotnet publish -c Release

# docker build -t my-webapi-image .

# docker run -d -p 1433:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa123456" --name my-sqlserver mcr.microsoft.com/mssql/server:2019-latest

# docker run -d -p 5000:5000 --name my-webapi my-webapi-image