﻿using System;
using Equipments.Domain.Entities;
using Equipments.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Equipments.Persistence.EntiryTypeConfiguration;
using System.Threading.Tasks;

#nullable disable

namespace Equipments.Persistence.Models
{
    public partial class EquipmentsDbContext : DbContext, IEquipmentsDbContext
    {
        public EquipmentsDbContext(DbContextOptions<EquipmentsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Act> Acts { get; set; }
        public DbSet<ActsAcceptEquipment> ActsAcceptEquipments { get; set; }
        public DbSet<ActsAddResource> ActsAddResources { get; set; }
        public DbSet<ActsDeleteEquipment> ActsDeleteEquipments { get; set; }
        public DbSet<ActsDeleteResource> ActsDeleteResources { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EqCustodiansOffice> EqCustodiansOffices { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCustodian> EquipmentCustodians { get; set; }
        public DbSet<EquipmentResource> EquipmentResources { get; set; }
        public DbSet<InventoryObject> InventoryObjects { get; set; }
        public DbSet<OfficeAssigment> OfficeAssigments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ProgressServiceRequest> ProgressServiceRequests { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<StatusEquipment> StatusEquipments { get; set; }
        public DbSet<StatusRequest> StatusRequests { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports { get; set; }
        public DbSet<TypeEquipment> TypeEquipments { get; set; }
        public DbSet<Worker> Workers { get; set; }

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
            modelBuilder.HasPostgresExtension("pgcrypto")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");


            modelBuilder.ApplyConfiguration(new ActConfiguration());
            modelBuilder.ApplyConfiguration(new ActsAcceptEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ActsAddResourceConfiguration());
            modelBuilder.ApplyConfiguration(new ActsDeleteEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ActsDeleteResourceConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EqCustodiansOfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentCustodianConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentResourceConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryObjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssigmentConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProgressServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new StatusEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new StatusRequestConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicalSupportConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());

            modelBuilder.HasSequence("inventory_number_seq");

            modelBuilder.HasSequence("number_act_seq");

            modelBuilder.HasSequence("number_res_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}