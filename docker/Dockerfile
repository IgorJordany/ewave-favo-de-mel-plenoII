FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /favo-de-mel

COPY *.sln ./

COPY src/Favo-de-mel.WebApi/Favo-de-mel.WebApi.csproj src/Favo-de-mel.WebApi/
COPY src/Favo-de-mel.Application/Favo-de-mel.Application.csproj src/Favo-de-mel.Application/
COPY src/Favo-de-mel.Core/Favo-de-mel.Core.csproj src/Favo-de-mel.Core/
COPY src/Favo-de-mel.Infrastructure/Favo-de-mel.Infrastructure.csproj src/Favo-de-mel.Infrastructure/
COPY src/Favo-de-mel.Shared/Favo-de-mel.Shared.csproj src/Favo-de-mel.Shared/
COPY test/Favo-de-mel.Tests/Favo-de-mel.Tests.csproj test/Favo-de-mel.Tests/

RUN dotnet restore

COPY . .

WORKDIR /favo-de-mel/src/Favo-de-mel.WebApi/
RUN dotnet build --configuration Release --output /app

FROM build AS publish

RUN dotnet publish --configuration Release --output /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "./Favo-de-mel.WebApi.dll"]
