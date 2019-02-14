using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace WebApplication1.Mapping
{
	public class TaskMapping : IEntityTypeConfiguration<Task>
	{
		public void Configure(EntityTypeBuilder<Task> builder)
		{
			builder.ToTable("Task");
			builder.HasKey(entity => entity.Id);
			builder.Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();
			builder.Property(e => e.Summary);
		}
	}
}
