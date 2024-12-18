using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;
using SistemaGimnasioV2.Services;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorizationCore();

// Servicios personalizados
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<InventoryAlertService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// Configuración de almacenamiento local
builder.Services.AddBlazoredLocalStorage();

// Configurar la cadena de conexión a la base de datos
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de HttpClient
builder.Services.AddHttpClient("ApiClient", client =>
{
    var baseAddress = builder.Configuration["ApiBaseAddress"];
    if (string.IsNullOrEmpty(baseAddress))
    {
        throw new InvalidOperationException("La clave ApiBaseAddress no está configurada en appsettings.json.");
    }
    client.BaseAddress = new Uri(baseAddress);
});

// Configuración de autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login/AccessDenied";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

builder.Services.AddControllers();

var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

// Inicialización de datos de ejemplo
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();
    SeedData.Initialize(dbContext);
}

app.Run();

// Clase para inicializar datos
public static class SeedData
{
    public static void Initialize(GymDbContext context)
    {
        // Aplicar migraciones pendientes si no existen
        try
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
        }

        // Crear un usuario de administrador si no existen datos
        if (!context.Users.Any())
        {
            context.Users.Add(new GymUser
            {
                Username = "admin",
                Password = HashPassword("admin123"), // Contraseña cifrada
                Role = "Administrador",
                Email = "admin@gimnasio.com",
                FirstName = "Admin",
                LastName = "Principal"
            });

            context.SaveChanges();
        }
    }

    // Método para cifrar contraseñas con SHA256
    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
