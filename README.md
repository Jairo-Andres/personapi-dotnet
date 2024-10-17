# personapi-dotnet
Este es un proyecto de API para la gestión de personas, estudios, profesiones y teléfonos. El proyecto utiliza ASP.NET Core y Entity Framework Core para manejar las operaciones CRUD de las diferentes entidades.

Requisitos previos

Para configurar el ambiente y desplegar el proyecto, necesitarás:

.NET SDK versión 8.0

Docker instalado y en ejecución

SQL Server como base de datos

Visual Studio o Visual Studio Code para desarrollo

Postman o Swagger UI para probar los endpoints de la API

Configuración del Ambiente

1. Clonar el Repositorio

Clona este repositorio a tu máquina local:

git clone <URL_del_repositorio>
cd personapi-dotnet

2. Configurar la Base de Datos

Asegúrate de tener SQL Server ejecutándose en tu máquina o en un contenedor Docker. Usa la cadena de conexión en appsettings.json para conectarte a tu base de datos. Modifica este archivo si es necesario para ajustar las credenciales y el servidor:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=persona_db;User Id=sa;Password=YourStrong!Passw0rd;"
  }
}

3. Restaurar las Dependencias

Desde la raíz del proyecto, ejecuta el siguiente comando para restaurar todas las dependencias:

dotnet restore

4. Crear y Aplicar Migraciones

Para asegurarte de que la base de datos está actualizada, ejecuta:

dotnet ef database update

Esto aplicará todas las migraciones pendientes a tu base de datos SQL Server.

5. Compilar el Proyecto

Para compilar el proyecto, ejecuta:

dotnet build

6. Ejecutar el Proyecto Localmente

Para ejecutar la API localmente en tu máquina, puedes usar:

dotnet run

Por defecto, la API se ejecutará en http://localhost:5000 (o en otro puerto especificado en el launchSettings.json).

7. Uso de Docker

a) Compilar la Imagen Docker

En la raíz del proyecto, asegúrate de tener tu Dockerfile y ejecuta:

docker build -t personapi-dotnet .

b) Ejecutar el Contenedor

Luego de compilar la imagen, puedes ejecutar el contenedor con:

docker run -p 8095:80 personapi-dotnet

La API estará disponible en http://localhost:8095.

8. Acceder a Swagger UI

Cuando el proyecto esté en ejecución, puedes acceder a la documentación interactiva Swagger UI en:

http://localhost:8095/swagger

Desde allí, podrás probar los endpoints de la API.

Despliegue

1. Despliegue con Docker

Puedes desplegar el proyecto en un servidor utilizando Docker. Solo asegúrate de que el servidor tenga Docker instalado y sigue estos pasos:

Sube la imagen Docker al registro de contenedores (por ejemplo, Docker Hub) o transfiérala a tu servidor.

Ejecuta la imagen en el servidor utilizando docker run con los parámetros adecuados.

2. Despliegue en un Servidor ASP.NET

Para desplegar en un servidor tradicional, como IIS o un servidor Linux con Nginx, puedes publicar la aplicación y transferir los archivos resultantes:

dotnet publish -c Release -o ./publish

Luego, transfiere el contenido de la carpeta publish al servidor y configura el servidor web para que sirva el sitio.

