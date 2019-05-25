using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Entities;

namespace TrainingZone.EFCore.EntityConfigurations
{
    class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.FirstPlayer).WithMany().HasForeignKey(u => u.FirstPlayerId);
            builder.HasOne(s => s.SecondPlayer).WithMany().HasForeignKey(u => u.SecondPlayerId);
        }
    }
}
