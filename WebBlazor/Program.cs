using Data.Repository.Common;
using Domain.Services;
using Data.Repository.API;
using Microsoft.AspNetCore.Authentication.Cookies;
using Radzen;
using WebBlazor.Components;
using WebBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios base de Blazor
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddRadzenComponents();

// --- INYECCIÓN DE DEPENDENCIAS ---

builder.Services.AddScoped<ClienteRepositoryAsync>();
builder.Services.AddScoped<IClienteRepository>(sp => sp.GetRequiredService<ClienteRepositoryAsync>());
builder.Services.AddScoped<IClienteRepositoryAsync>(sp => sp.GetRequiredService<ClienteRepositoryAsync>());

builder.Services.AddScoped<CategoriaRepositoryAsync>();
builder.Services.AddScoped<ICategoriaRepository>(sp => sp.GetRequiredService<CategoriaRepositoryAsync>());
builder.Services.AddScoped<ICategoriaRepositoryAsync>(sp => sp.GetRequiredService<CategoriaRepositoryAsync>());

builder.Services.AddScoped<IArticuloRepository, ArticuloRepositoryAsync>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
// 2. Servicios de Dominio
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CategoriaService>();

// 3. Servicios Auxiliares de la Web
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<WebBlazor.Services.ExportService>();

// --- AUTENTICACIÓN ---
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "auth_cookie_blazor";
		options.LoginPath = "/";
		options.ExpireTimeSpan = TimeSpan.FromHours(8);
	});

builder.Services.AddAuthorization();

// HttpClient configurado para la API (usado por el Repositorio Async)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000/") });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();