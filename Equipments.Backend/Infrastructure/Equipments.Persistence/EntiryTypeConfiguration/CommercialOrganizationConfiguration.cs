using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class CommercialOrganizationConfiguration : IEntityTypeConfiguration<CommercialOrganization>
    {
        public void Configure(EntityTypeBuilder<CommercialOrganization> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("CommercialOrganizations_pkey");

            entity.ToTable("CommercialOrganizations");

            entity.HasIndex(e => new { e.Name, e.Phone, e.Email, e.Website }, "index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("Email");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("Name");

            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("Phone");

            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("Website");
        }
    }
}
