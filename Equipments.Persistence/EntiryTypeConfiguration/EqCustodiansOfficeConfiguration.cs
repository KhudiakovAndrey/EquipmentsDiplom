using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class EqCustodiansOfficeConfiguration : IEntityTypeConfiguration<EqCustodiansOffice>
    {
        public void Configure(EntityTypeBuilder<EqCustodiansOffice> entity)
        {
            entity.HasNoKey();

            entity.ToTable("eq_custodians_office");

            entity.Property(e => e.Кабинет).HasMaxLength(4);

            entity.Property(e => e.Ответсвенный).HasMaxLength(300);
        }
    }
}
