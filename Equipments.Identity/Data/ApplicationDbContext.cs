using Equipments.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equipments.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "AspNetUsers"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "AspNetRoles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "AspNetUserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "AspNetUserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable("AspNetUserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable("AspNetUserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable("AspNetRoleClaims"));

            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
