using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Iduser)
                    .HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Userlogin, "users_userlogin_key")
                .IsUnique();

            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.Property(e => e.Datelastlogin).HasColumnName("datelastlogin");

            entity.Property(e => e.Dateregistration).HasColumnName("dateregistration");

            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");

            entity.Property(e => e.Idworker).HasColumnName("idworker");

            entity.Property(e => e.Isactive).HasColumnName("isactive");

            entity.Property(e => e.Isregemailactive).HasColumnName("isregemailactive");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Userlogin)
                .HasMaxLength(50)
                .HasColumnName("userlogin");

            entity.Property(e => e.Userpassword)
                .HasMaxLength(20)
                .HasColumnName("userpassword");

            entity.HasOne(d => d.IdworkerNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.Idworker)
                .HasConstraintName("users_idworker_fkey");
        }
    }
}
