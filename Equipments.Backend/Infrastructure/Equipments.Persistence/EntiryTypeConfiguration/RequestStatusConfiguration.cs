using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
    {
        public void Configure(EntityTypeBuilder<RequestStatus> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("request_statuses_pkey");

            entity.ToTable("request_statuses");

            entity.HasIndex(e => e.Name, "request_statuses_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
        }
    }
}
