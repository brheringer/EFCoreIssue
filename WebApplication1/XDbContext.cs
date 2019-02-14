using WebApplication1.Model;
using WebApplication1.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1
{
	public class XDbContext : DbContext //EFDBContext
	{
		public DbSet<Sprint> SprintDbSet { get; private set; }
		public DbSet<Task> TaskDbSet { get; private set; }

		public XDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new SprintBacklogItemMapping());
			modelBuilder.ApplyConfiguration(new SprintMapping());
			modelBuilder.ApplyConfiguration(new TaskMapping());
		}
	}
}
