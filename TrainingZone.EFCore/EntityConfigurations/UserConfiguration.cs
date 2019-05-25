using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.EFCore.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Score).WithOne().HasForeignKey(s => new { s.SecondPlayerId, s.FirstPlayerId });
        }
    }
}
