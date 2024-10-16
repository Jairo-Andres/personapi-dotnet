using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Esto debería ser suficiente para generar la documentación Swagger

// Configurar para escuchar en todas las interfaces (0.0.0.0) y en el puerto 80
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Configurar Entity Framework y la cadena de conexión
builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios
builder.Services.AddScoped<PersonaRepository>();
builder.Services.AddScoped<ProfesionRepository>();
builder.Services.AddScoped<EstudioRepository>();
builder.Services.AddScoped<TelefonoRepository>();

var app = builder.Build();

// Aplicar migraciones pendientes si existen
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PersonaDbContext>();

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();
    }
}

// Configuración de middleware para el manejo de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    // Usar Swagger en entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person API v1");
    });
}

// Redireccionar HTTP a HTTPS
app.UseHttpsRedirection();

// Servir archivos estáticos
app.UseStaticFiles();

// Configurar enrutamiento
app.UseRouting();

// Configurar autorización
app.UseAuthorization();

// Mapear rutas de controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
