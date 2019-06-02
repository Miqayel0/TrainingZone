using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Entities;

namespace TrainingZone.EFCore.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasOne(g => g.FirstPlayer).WithMany(u => u.Games).HasForeignKey(g => g.FirstPlayerId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(g => g.Score).WithOne(s => s.Game).HasForeignKey<Game>(g => g.ScoreId);
        }
    }
}
