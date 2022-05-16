# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c release -o /app

WORKDIR /app

ENTRYPOINT ["dotnet", "adopse-2021.dll"]

#TODO: switch to this later
## final stage/image
#FROM mcr.microsoft.com/dotnet/runtime:6.0
#WORKDIR /app
#COPY --from=build /app .
