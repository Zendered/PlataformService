using Microsoft.EntityFrameworkCore;
using PlataformServiceAPI.Models;

namespace PlataformServiceAPI.Data;

public class AppDbContext : DbContext
{
	public DbSet<Platform> Platforms { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Platform>()
			.Property(c => c.Name)
			.HasMaxLength(100)
			.IsRequired();

		modelBuilder.Entity<Platform>()
			.Property(c => c.Publisher)
			.HasMaxLength(100)
			.IsRequired();

		modelBuilder.Entity<Platform>()
			.Property(c => c.Cost)
			.IsRequired();
	}
}
