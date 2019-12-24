using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class AxosContext : DbContext
{
  public DbSet<User> FreeUsers { get; set; }

  public AxosContext(DbContextOptions<AxosContext> options)
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
    //TODO: Configurar en archivos separados, agregar non-c indexes.

    // modelBuilder.Entity<AppUser>().ToTable("AppUsers", "test");
    // modelBuilder.Entity<AppUser>(entity =>
    // {
    //   entity.HasKey(e => e.Id);
    //   entity.HasIndex(e => e.Nombre).IsUnique();    
    // });

    base.OnModelCreating(modelBuilder);
  }
}