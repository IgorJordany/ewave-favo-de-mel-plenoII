FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /favodemel

COPY *.sln ./

COPY src/FavoDeMel.Api/FavoDeMel.Api.csproj src/FavoDeMel.Api/
COPY src/FavoDeMel.Application/FavoDeMel.Application.csproj src/FavoDeMel.Application/
COPY src/FavoDeMel.Core/FavoDeMel.Core.csproj src/FavoDeMel.Core/
COPY src/FavoDeMel.Infrastructure/FavoDeMel.Infrastructure.csproj src/FavoDeMel.Infrastructure/
COPY src/FavoDeMel.Shared/FavoDeMel.Shared.csproj src/FavoDeMel.Shared/
COPY test/FavoDeMel.Tests/FavoDeMel.Tests.csproj test/FavoDeMel.Tests/

RUN dotnet restore

COPY . .

WORKDIR /favodemel/src/FavoDeMel.Api/
RUN dotnet build --configuration Release --output /app

FROM build AS publish

RUN dotnet publish --configuration Release --output /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "./FavoDeMel.Api.dll"]
