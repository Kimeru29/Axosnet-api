using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AxosContext : DbContext
{
  public DbSet<Usuario> Usuarios { get; set; }
  public DbSet<Provedor> Provedores { get; set; }
  public DbSet<MetodoPago> MetodoPago { get; set; }
  public DbSet<Recibo> Recibos { get; set; }

  public AxosContext(DbContextOptions options)
   : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Filename=AxosDevEnv.db", options =>
      options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
    );

    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //TODO: Método Seed.
    //TODO: Configurar en archivos separados, agregar non-c indexes.
    modelBuilder.Entity<Usuario>()
      .ToTable("Usuarios");
    modelBuilder.Entity<MetodoPago>()
      .ToTable("MetodosPago");
    modelBuilder.Entity<Provedor>()
      .ToTable("Provedores");
    modelBuilder.Entity<Recibo>()
      .ToTable("Recibos");

    modelBuilder.Entity<Usuario>()
      .Property(u => u.Genero)
      .HasConversion<int>();

    // modelBuilder.Entity<Recibo>()
    //   .HasIndex(r => r.)
    base.OnModelCreating(modelBuilder);
  }
}