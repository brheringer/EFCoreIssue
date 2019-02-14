using WebApplication1.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Mapping
{
	public class SprintBacklogItemMapping : IEntityTypeConfiguration<SprintBacklogItem>
	{
		public void Configure(EntityTypeBuilder<SprintBacklogItem> builder)
		{
			builder.ToTable("SprintBacklogItem");
			builder.HasKey(entity => entity.Id);
			builder.Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();

			builder.HasOne(e => e.PlannedSprint).WithMany(s => s.SprintBacklog);
			builder.HasOne(e => e.PlannedTask).WithMany().IsRequired();
		}

	}
}
