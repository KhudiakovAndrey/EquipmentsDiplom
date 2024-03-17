using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class OfficeAssigmentConfiguration : IEntityTypeConfiguration<OfficeAssigment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssigment> entity)
        {
            entity.HasKey(e => e.NumberOffice)
                                .HasName("number_office_fk");

            entity.ToTable("office_assigments");

            entity.HasIndex(e => e.NumberOffice, "number_office_unique")
                .IsUnique();

            entity.Property(e => e.NumberOffice)
                .HasMaxLength(4)
                .HasColumnName("number_office");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        }
    }
}
