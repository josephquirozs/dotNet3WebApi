# dotNetApiExample
ASP.NET Core web API example.

## Run database manually
Execute script file [create_database.sql](database/create_database.sql) in your server

## Run database using docker run
```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sa123456" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

## Load test data
Execute script file [insert_test_data.sql](database/insert_test_data.sql) in your server