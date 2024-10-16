# Usar la imagen base oficial de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usar la imagen base oficial de SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo de proyecto y restaurar dependencias
COPY ["personapi-dotnet.csproj", "./"]

# Añadir el paquete Swashbuckle.AspNetCore dentro del archivo de proyecto
RUN dotnet add package Swashbuckle.AspNetCore 

# Restaurar las dependencias del proyecto
RUN dotnet restore "./personapi-dotnet.csproj"

# Copiar todo el código fuente y construir
COPY . .
WORKDIR "/src/."
RUN dotnet build "personapi-dotnet.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "personapi-dotnet.csproj" -c Release -o /app/publish

# Crear la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "personapi-dotnet.dll"]
