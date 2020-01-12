# Restore NuGet packages
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
RUN pwd
COPY *.sln .
COPY Kontofonen.Web/*.csproj Kontofonen.Web/
COPY Kontofonen.Domain/*.csproj Kontofonen.Domain/
COPY Kontofonen.TypeScript.TypeGenerator/*.csproj Kontofonen.TypeScript.TypeGenerator/
RUN dotnet restore
COPY . .

# Publish server
FROM build AS publish
WORKDIR /src/Kontofonen.Web
RUN dotnet publish -c Release -o /src/publish
WORKDIR /src/Kontofonen.TypeScript.TypeGenerator
RUN dotnet build -c Release --runtime ubuntu.16.04-x64
WORKDIR /src/Kontofonen.TypeScript.TypeGenerator/bin/Release/ubuntu.16.04-x64
RUN /src/Kontofonen.TypeScript.TypeGenerator/bin/Release/ubuntu.16.04-x64/Kontofonen.TypeScript.TypeGenerator

# Build client
FROM node:10 AS client
WORKDIR /src/Kontofonen.Web/Client
COPY --from=publish /src/Kontofonen.Web/Client/types types
COPY Kontofonen.Web/Client/package.json .
COPY Kontofonen.Web/Client/package-lock.json .
RUN npm install
COPY Kontofonen.Web/Client/ .
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=client /src/Kontofonen.Web/Client/build Client/build
# ENTRYPOINT ["dotnet", "Kontofonen.Web.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Kontofonen.Web.dll
