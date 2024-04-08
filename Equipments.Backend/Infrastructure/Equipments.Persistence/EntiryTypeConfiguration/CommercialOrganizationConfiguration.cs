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
                  .HasName("commercial_organizations_pkey");

            entity.ToTable("commercial_organizations");

            entity.HasIndex(e => new { e.Name, e.Phone, e.Email, e.Website }, "commercial_organizations_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");

            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
        }
    }
}
