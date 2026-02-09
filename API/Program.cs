using Data.Common;
using Data.Repository.Common;
using Data.Repository.EF;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONEXIÓN Y DEPENDENCIAS
builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClienteRepository, Data.Repository.EF.ClienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CategoriaService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "auth_token";
		options.LoginPath = "/api/auth/login";
		options.Events.OnRedirectToLogin = context =>
		{
			context.Response.StatusCode = 401;
			return Task.CompletedTask;
		};
	});

builder.Services.AddAuthentication();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
