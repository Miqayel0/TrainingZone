using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Entities;

namespace TrainingZone.EFCore.EntityConfigurations
{
    class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Player).WithMany(u => u.Steps).HasForeignKey(p => p.PlayerId);
            builder.HasMany(p => p.Games);
        }
    }
}
