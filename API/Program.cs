using Data.Common;
using Data.Repository.API;
using Data.Repository.Common;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
	});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONEXIÓN Y DEPENDENCIAS
builder.Services.AddDbContext<TestDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
	ServiceLifetime.Scoped);
builder.Services.AddScoped<IClienteRepository, Data.Repository.EF.ClienteRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<Domain.Services.CategoriaService>();
builder.Services.AddScoped<Data.Repository.Common.ICategoriaRepository>(provider =>
{
	var context = provider.GetRequiredService<TestDbContext>();
	return new Data.Repository.API.CategoriaRepository(context);
});

//CONFIGURACION COOKIE
builder.Services.AddAuthentication(options => {
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
	{
		options.Cookie.Name = "auth_token";
		options.LoginPath = "/";
		options.Events.OnRedirectToLogin = context =>
		{
			context.Response.StatusCode = 401;
			return Task.CompletedTask;
		};
		options.ExpireTimeSpan = TimeSpan.FromHours(8);
	});

builder.Services.AddAuthorization();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication(); 
app.UseAuthorization();    
app.MapControllers();
app.Run();
