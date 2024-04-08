using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Equipments.Domain.Entities;
using Equipments.Application.Interfaces;
using System.Threading.Tasks;
using Equipments.Persistence.EntityTypeConfiguration;

#nullable disable

namespace Equipments.Persistence.Models
{
    public partial class EquipmentsBusinessContext : DbContext, IEquipmentsDbContext
    {
        public EquipmentsBusinessContext()
        {
        }

        public EquipmentsBusinessContext(DbContextOptions<EquipmentsBusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignedOffice> AssignedOffices { get; set; }
        public virtual DbSet<CommercialOffer> CommercialOffers { get; set; }
        public virtual DbSet<CommercialOrganization> CommercialOrganizations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EquipmentPurchaseRequest> EquipmentPurchaseRequests { get; set; }
        public virtual DbSet<EquipmentServiceRequest> EquipmentServiceRequests { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProblemType> ProblemTypes { get; set; }
        public virtual DbSet<PurchasedEquipment> PurchasedEquipments { get; set; }
        public virtual DbSet<RequestComment> RequestComments { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<RequestStatusChange> RequestStatusChanges { get; set; }

        public async Task<bool> CheckConnectionAsync()
        {
            var connection = Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.ApplyConfiguration(new AssignedOfficeConfiguration());
            modelBuilder.ApplyConfiguration(new CommercialOfferConfiguration());
            modelBuilder.ApplyConfiguration(new CommercialOrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentPurchaseRequestConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProblemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasedEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new RequestCommentConfiguration());
            modelBuilder.ApplyConfiguration(new RequestStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RequestStatusChangeConfiguration());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
