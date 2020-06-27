# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

COPY Goblin.Core/Goblin.Core/*.csproj ./Goblin.Core/Goblin.Core/
COPY Goblin.Core/Goblin.Core.Web/*.csproj ./Goblin.Core/Goblin.Core.Web/

COPY src/Cross/Goblin.Api_Base.Core/*.csproj ./src/Cross/Goblin.Api_Base.Core/
COPY src/Cross/Goblin.Api_Base.Mapper/*.csproj ./src/Cross/Goblin.Api_Base.Mapper/
COPY src/Cross/Goblin.Api_Base.Share/*.csproj ./src/Cross/Goblin.Api_Base.Share/

COPY src/Repository/Goblin.Api_Base.Contract.Repository/*.csproj ./src/Repository/Goblin.Api_Base.Contract.Repository/
COPY src/Repository/Goblin.Api_Base.Repository/*.csproj ./src/Repository/Goblin.Api_Base.Repository/

COPY src/Service/Goblin.Api_Base.Contract.Service/*.csproj ./src/Service/Goblin.Api_Base.Contract.Service/
COPY src/Service/Goblin.Api_Base.Service/*.csproj ./src/Service/Goblin.Api_Base.Service/

COPY src/Web/Goblin.Api_Base/*.csproj ./src/Web/Goblin.Api_Base/

RUN dotnet restore

# copy everything else and build app

COPY Goblin.Core/Goblin.Core/. ./Goblin.Core/Goblin.Core/
COPY Goblin.Core/Goblin.Core.Web/. ./Goblin.Core/Goblin.Core.Web/

COPY src/Cross/Goblin.Api_Base.Core/. ./src/Cross/Goblin.Api_Base.Core/
COPY src/Cross/Goblin.Api_Base.Mapper/. ./src/Cross/Goblin.Api_Base.Mapper/
COPY src/Cross/Goblin.Api_Base.Share/. ./src/Cross/Goblin.Api_Base.Share/

COPY src/Repository/Goblin.Api_Base.Contract.Repository/. ./src/Repository/Goblin.Api_Base.Contract.Repository/
COPY src/Repository/Goblin.Api_Base.Repository/. ./src/Repository/Goblin.Api_Base.Repository/

COPY src/Service/Goblin.Api_Base.Contract.Service/. ./src/Service/Goblin.Api_Base.Contract.Service/
COPY src/Service/Goblin.Api_Base.Service/. ./src/Service/Goblin.Api_Base.Service/

COPY src/Web/Goblin.Api_Base/. ./src/Web/Goblin.Api_Base/

WORKDIR /source
RUN dotnet publish -c release -o /publish --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /publish
COPY --from=build /publish ./
ENTRYPOINT ["dotnet", "Goblin.Api_Base.dll"]