namespace Test2026
{
    using Data.Common;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Domain.Services;
    using Data.Repository.Common;
    using Data.Repository.EF;
	using Desktop;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
					services.AddDbContext<TestDbContext>(options =>
						options.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=Test1;Persist Security Info=True;Trusted_Connection=True;TrustServerCertificate=True"));

					services.AddScoped<IClienteRepository, ClienteRepository>();
					services.AddScoped<ICategoriaRepository, CategoriaRepository>();
					services.AddScoped<ClienteService>();
                    services.AddScoped<CategoriaService>();
                    services.AddScoped<ClientesForm>();
                    services.AddScoped<ClientesInsertForm>();
                    services.AddScoped<ClientesEditForm>();
                })
                .Build();

            var form = host.Services.GetRequiredService<ClientesForm>();
            Application.Run(form);
        }
    }
}