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
                  .HasName("Employees_pkey");

            entity.ToTable("Employees");

            entity.HasIndex(e => new { e.FullName, e.Photo }, "employees_ID_index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("FullName");

            entity.Property(e => e.IdassignedOffice).HasColumnName("IDAssignedOffice");

            entity.Property(e => e.Iddepartment).HasColumnName("IDDepartment");

            entity.Property(e => e.Idpost).HasColumnName("IDPost");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");

            entity.Property(e => e.IDEmployeeRole).HasColumnName("IDEmployeeRole");

            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .HasColumnName("Photo");

            entity.HasOne(d => d.IdassignedOfficeNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdassignedOffice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_AssignedOffices");

            entity.HasOne(d => d.EmployeeRole)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.IDEmployeeRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employees_IDEmployeeRole_fkey");

            entity.HasOne(d => d.IddepartmentNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.Iddepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.IdpostNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idpost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Posts");
        }
    }
}
