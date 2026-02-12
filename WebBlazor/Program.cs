using Data.Repository.Common;
using Domain.Services;
using Data.Repository.API;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using WebBlazor.Components;
using WebBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios base
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddControllers(); 
builder.Services.AddRadzenComponents();

// Inyección de dependencias existente
builder.Services.AddScoped<IClienteRepository, Data.Repository.API.ClienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, Data.Repository.API.CategoriaRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CategoriaService>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ExportService>();

// Configuración de Autenticación en Blazor
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "auth_cookie_blazor";
		options.LoginPath = "/";
		options.ExpireTimeSpan = TimeSpan.FromHours(8);
	});

builder.Services.AddAuthorization();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();

// HttpClient configurado para la API
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