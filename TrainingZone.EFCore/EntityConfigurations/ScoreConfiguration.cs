using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingZone.Core.Entities;

namespace TrainingZone.EFCore.EntityConfigurations
{
    class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.FirstPlayer).WithMany(u => u.Score).HasForeignKey(s => s.FirstPlayerId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
