using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class CommercialOfferConfiguration : IEntityTypeConfiguration<CommercialOffer>
    {
        public void Configure(EntityTypeBuilder<CommercialOffer> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("CommercialOffers_pkey");

            entity.ToTable("CommercialOffers");

            entity.HasIndex(e => new { e.Price, e.IdcommercialOrganization, e.InformationSource }, "CommercialOffers_INDEX");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.IdcommercialOrganization).HasColumnName("IDCommercialOrganization");

            entity.Property(e => e.IdequipmentPurchaseRequest).HasColumnName("IDEquipmentPurchaseRequest");

            entity.Property(e => e.InformationSource)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("InformationSource");

            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.IdcommercialOrganizationNavigation)
                .WithMany(p => p.CommercialOffers)
                .HasForeignKey(d => d.IdcommercialOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommercialOffers_CommercialOrganization");

            entity.HasOne(d => d.IdequipmentPurchaseRequestNavigation)
                .WithMany(p => p.CommercialOffers)
                .HasForeignKey(d => d.IdequipmentPurchaseRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommercialOffers_EquipmentPurchaseRequest");
        }
    }
}