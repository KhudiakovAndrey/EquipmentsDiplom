using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => new { e.FullName, e.Photo }, "employees_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("full_name");

            entity.Property(e => e.IdassignedOffice).HasColumnName("idassigned_office");

            entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");

            entity.Property(e => e.Idpost).HasColumnName("idpost");

            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("photo");

            entity.HasOne(d => d.IdassignedOfficeNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdassignedOffice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employees_assigned_offices_id");

            entity.HasOne(d => d.IddepartmentNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.Iddepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employees_departments_id");

            entity.HasOne(d => d.IdpostNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idpost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employees_posts_id");
        }
    }
}
