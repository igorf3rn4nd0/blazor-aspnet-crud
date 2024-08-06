FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["ClientApp/ClientApp.csproj", "ClientApp/"]
RUN dotnet restore "ClientApp/ClientApp.csproj"

COPY ["SharedModels/SharedModels.csproj", "SharedModels/"]
COPY [".", "ClientApp/"]

WORKDIR "/src/ClientApp"
RUN dotnet build "ClientApp/ClientApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientApp/ClientApp.csproj" -c Release -o /app/publish

# Etapa 4: Final
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientApp.dll"]
