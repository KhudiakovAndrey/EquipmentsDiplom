using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class RequestCommentConfiguration : IEntityTypeConfiguration<RequestComment>
    {
        public void Configure(EntityTypeBuilder<RequestComment> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("request_comments_pkey");

            entity.ToTable("request_comments");

            entity.HasIndex(e => e.Comment, "request_comments_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Comment)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("comment");

            entity.Property(e => e.Idemployee).HasColumnName("idemployee");

            entity.Property(e => e.IdequipmentServiceRequest).HasColumnName("idequipment_service_request");

            entity.HasOne(d => d.IdemployeeNavigation)
                .WithMany(p => p.RequestComments)
                .HasForeignKey(d => d.Idemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_comments_employee_id");

            entity.HasOne(d => d.IdequipmentServiceRequestNavigation)
                .WithMany(p => p.RequestComments)
                .HasForeignKey(d => d.IdequipmentServiceRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_comments_equipment_service_request_id");
        }
    }
}
