using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class StatusRequestConfiguration : IEntityTypeConfiguration<StatusRequest>
    {
        public void Configure(EntityTypeBuilder<StatusRequest> entity)
        {
            entity.HasKey(e => e.IdStatusRequest)
                                .HasName("status_request_pkey");

            entity.ToTable("status_requests");

            entity.Property(e => e.IdStatusRequest)
                .HasColumnName("id_status_request")
                .HasDefaultValueSql("nextval('status_request_id_status_request_seq'::regclass)");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");
        }
    }
}
