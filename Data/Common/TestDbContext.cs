using System;
using System.Collections.Generic;
using Data.Modelo;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Common;

public partial class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Categoria> Categorias { get; set; }
	public virtual DbSet<Usuario> Usuarios { get; set; }
	public DbSet<Log> Logs { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
