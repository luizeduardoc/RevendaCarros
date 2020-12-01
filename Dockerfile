FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app

COPY *.sln .
COPY RevendaCarros.Api/*.csproj ./RevendaCarros.Api/
COPY RevendaCarros.Domain/*.csproj ./RevendaCarros.Domain/
COPY ./RevendaCarros.Infrastructure/*.csproj ./RevendaCarros.Infrastructure/
COPY ./RevendaCarros.UnitTest/*.csproj ./RevendaCarros.UnitTest/

RUN dotnet restore

COPY RevendaCarros.Api/. ./RevendaCarros.Api/
COPY RevendaCarros.Domain/. ./RevendaCarros.Domain/
COPY RevendaCarros.Infrastructure/. ./RevendaCarros.Infrastructure/
COPY RevendaCarros.UnitTest/. ./RevendaCarros.UnitTest/

RUN dotnet test RevendaCarros.UnitTest/*.csproj

WORKDIR /app
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
COPY --from=build /app/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RevendaCarros.Api.dll