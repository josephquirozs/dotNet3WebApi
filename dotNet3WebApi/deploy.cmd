@echo off
dotnet clean -c Release
dotnet publish -c Release
docker build -t my-api-image:0.0.P1 .
docker run -d -p 5000:5000 --name my-api-0.0.P1 my-api-image:0.0.P1