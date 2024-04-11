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
                  .HasName("RequestStatuses_pkey");

            entity.ToTable("RequestStatuses");

            entity.HasIndex(e => e.Name, "RequestStatuses_index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");
        }
    }
}
