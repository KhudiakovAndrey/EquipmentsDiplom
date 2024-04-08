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
                  .HasName("commercial_offers_pkey");

            entity.ToTable("commercial_offers");

            entity.HasIndex(e => new { e.Price, e.IdcommercialOrganization, e.InformationSource }, "commercial_offers_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdcommercialOrganization).HasColumnName("idcommercial_organization");

            entity.Property(e => e.IdequipmentPurchaseRequest).HasColumnName("idequipment_purchase_request");

            entity.Property(e => e.InformationSource)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("information_source");

            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.IdcommercialOrganizationNavigation)
                .WithMany(p => p.CommercialOffers)
                .HasForeignKey(d => d.IdcommercialOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_commercial_offers_commercial_organization_id");

            entity.HasOne(d => d.IdequipmentPurchaseRequestNavigation)
                .WithMany(p => p.CommercialOffers)
                .HasForeignKey(d => d.IdequipmentPurchaseRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_commercial_offers_equipment_purchase_request_id");
        }
    }
}