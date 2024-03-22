using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ActsAddResourceConfiguration : IEntityTypeConfiguration<ActsAddResource>
    {
        public void Configure(EntityTypeBuilder<ActsAddResource> entity)
        {
            entity.HasKey(e => e.IdActAddResources)
                                .HasName("acts_add_resources_pkey");

            entity.ToTable("acts_add_resources");

            entity.Property(e => e.IdActAddResources).HasColumnName("id_act_add_resources");

            entity.Property(e => e.CostRes)
                .HasColumnType("money")
                .HasColumnName("cost_res");

            entity.Property(e => e.CountRes).HasColumnName("count_res");

            entity.Property(e => e.NumberAct)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_act");

            entity.Property(e => e.NumberRes)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_res");

            entity.HasOne(d => d.NumberActNavigation)
                .WithMany(p => p.ActsAddResources)
                .HasForeignKey(d => d.NumberAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_act_fk");

            entity.HasOne(d => d.NumberResNavigation)
                .WithMany(p => p.ActsAddResources)
                .HasForeignKey(d => d.NumberRes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_res_fk");
        }
    }
}
