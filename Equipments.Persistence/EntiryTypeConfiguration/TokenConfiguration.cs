using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class TokenConfiguration :
        IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> entity)
        {
            entity.ToTable("tokens");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.Property(e => e.Tokencontent)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("tokencontent");

            entity.HasOne(d => d.IduserNavigation)
                .WithMany(p => p.Tokens)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tokens_iduser_fkey");
        }

    }
}
