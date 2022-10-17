# Builder start
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal AS builder
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o bundle
# Builder end

# Runner start
FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS runner
WORKDIR /app
RUN apt-get install -y tzdata
COPY --from=builder /app/bundle .
ENTRYPOINT ["dotnet", "dotNet3WebApi.dll"]
# Runner end