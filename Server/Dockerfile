# Use a imagem base do .NET SDK para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho
WORKDIR /src

# Copie os arquivos do projeto e restaure as dependências
COPY Server/Server.csproj Server/
COPY SharedModels/SharedModels.csproj SharedModels/
RUN dotnet restore Server/Server.csproj

# Copie o restante dos arquivos e construa o projeto
COPY Server/. Server/
COPY SharedModels/. SharedModels/
RUN dotnet publish Server/Server.csproj -c Release -o /app/publish

# Use uma imagem base do .NET Runtime para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Defina o comando para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Server.dll"]
