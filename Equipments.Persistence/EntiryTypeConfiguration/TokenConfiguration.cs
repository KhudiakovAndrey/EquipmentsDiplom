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
            entity.HasKey(e => e.Key)
    .HasName("Tokens_pkey");

            entity.Property(e => e.Key).HasMaxLength(200);

            entity.Property(e => e.AccessToken)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ClientId)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.CreationTime).HasColumnType("timestamp with time zone");

            entity.Property(e => e.Data)
                .IsRequired()
                .HasColumnType("jsonb");

            entity.Property(e => e.Expires).HasColumnType("timestamp with time zone");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tokens_AspNetUsers_UserId");

        }

    }
}
