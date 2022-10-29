using Microsoft.EntityFrameworkCore;
using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Data;

public class AppDbContext : DbContext
{
	public DbSet<Plataform> Plataforms { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Plataform>()
			.Property(c => c.Name)
			.HasMaxLength(100)
			.IsRequired();

		modelBuilder.Entity<Plataform>()
			.Property(c => c.Publisher)
			.HasMaxLength(100)
			.IsRequired();

		modelBuilder.Entity<Plataform>()
			.Property(c => c.Cost)
			.IsRequired();
	}
}
