using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.HasIndex(e => e.NormalizedEmail, "IX_AspNetUsers_Email")
                    .IsUnique();

            entity.HasIndex(e => e.NormalizedUserName, "IX_AspNetUsers_UserName")
                .IsUnique();

            entity.Property(e => e.ConcurrencyStamp)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.LastLoginDate).HasColumnType("timestamp with time zone");

            entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

            entity.Property(e => e.NormalizedEmail)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.NormalizedUserName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.RegistrationDate).HasColumnType("timestamp with time zone");

            entity.Property(e => e.SecurityStamp)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Worker)
                .WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("AppUsers_WorkerID_fkey");
        }
    }
}
