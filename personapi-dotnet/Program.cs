using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar los controladores para la API
builder.Services.AddControllers();

// Agregar la configuración de Entity Framework y la cadena de conexión
builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar todos los repositorios
builder.Services.AddScoped<PersonaRepository>();   // Repositorio para Persona
builder.Services.AddScoped<ProfesionRepository>(); // Repositorio para Profesion
builder.Services.AddScoped<EstudioRepository>();   // Repositorio para Estudio
builder.Services.AddScoped<TelefonoRepository>();  // Repositorio para Telefono

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
