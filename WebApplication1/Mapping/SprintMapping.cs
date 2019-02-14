using WebApplication1.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Mapping
{
	public class SprintMapping : IEntityTypeConfiguration<Sprint>
	{
		public void Configure(EntityTypeBuilder<Sprint> builder)
		{
			builder.ToTable("Sprint");
			builder.HasKey(entity => entity.Id);
			builder.Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();

			builder.Property(e => e.InitialDate).IsRequired();
			builder.Property(e => e.FinalDate).IsRequired();
			//builder.HasMany(e => e.SprintBacklog).WithOne(item => item.PlannedSprint);
		}
	}
}
