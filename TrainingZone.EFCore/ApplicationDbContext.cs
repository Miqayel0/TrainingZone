﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Entities;
using TrainingZone.EFCore.EntityConfigurations;

namespace TrainingZone.EFCore
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
              : base(options)
        {
        }

        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Point> Coordinates { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ScoreConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new PointConfiguration());
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
