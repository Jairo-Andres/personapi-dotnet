# personapi-dotnet

Este es un proyecto de API para la gestión de personas, estudios, profesiones y teléfonos. El proyecto utiliza ASP.NET Core y Entity Framework Core para manejar las operaciones CRUD de las diferentes entidades.

## Requisitos previos

Para configurar el ambiente y desplegar el proyecto, necesitarás:

- **.NET SDK** versión 8.0
- **Docker** instalado y en ejecución
- **SQL Server** como base de datos
- **Visual Studio** o **Visual Studio Code** para desarrollo
- **Postman** o **Swagger UI** para probar los endpoints de la API

## Configuración del Ambiente y Despliegue

### 1. Clonar el Repositorio

Clona este repositorio a tu máquina local:

```bash
git clone <[URL_del_repositorio](https://github.com/Jairo-Andres/personapi-dotnet)>
cd personapi-dotnet
```
### 2. Configurar la Base de Datos
Asegúrate de tener SQL Server ejecutándose en tu máquina o en un contenedor Docker. Usa la cadena de conexión en appsettings.json para conectarte a tu base de datos. Modifica este archivo si es necesario para ajustar las credenciales y el servidor:
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=persona_db;User Id=sa;Password=YourStrong!Passw0rd;"
  }
}
```
### 3. Restaurar las Dependencias
Desde la raíz del proyecto, ejecuta el siguiente comando para restaurar todas las dependencias:
```bash
dotnet restore
```
### 4. Crear y Aplicar Migraciones
Para asegurarte de que la base de datos está actualizada, ejecuta:
```bash
dotnet ef database update
```
Esto aplicará todas las migraciones pendientes a tu base de datos SQL Server.
### 5. Compilar el Proyecto
Para compilar el proyecto, ejecuta:
```bash
dotnet build
```
### 6. Ejecutar el Proyecto Localmente
Para ejecutar la API localmente en tu máquina, puedes usar:
```bash
dotnet run
```
Por defecto, la API se ejecutará en http://localhost:5135 (o en otro puerto especificado en el launchSettings.json).
### 7. Uso de Docker
Para ejecutar el proyecto dentro de un contenedor Docker:
-  Compilar la Imagen Docker -> En la raíz del proyecto, asegúrate de tener tu Dockerfile y ejecuta:
```bash
docker build -t personapi-dotnet .
```
- Ejecutar el Contenedor -> Luego de compilar la imagen, puedes ejecutar el contenedor con:  
```bash
docker run -p 8095:80 personapi-dotnet
```
La API estará disponible en http://localhost:8095.
### 8. Acceder a Swagger UI
Cuando el proyecto esté en ejecución, puedes acceder a la documentación interactiva Swagger UI en:
```bash
[dotnet run](http://localhost:8095/swagger)
```
Desde allí, se podra probar los endpoints de la API.
