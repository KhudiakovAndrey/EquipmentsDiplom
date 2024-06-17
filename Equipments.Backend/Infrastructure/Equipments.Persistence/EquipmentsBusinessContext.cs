using Dapper;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Persistence.EntiryTypeConfiguration;
using Equipments.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable

namespace Equipments.Persistence.Models
{
    public partial class EquipmentsBusinessContext : DbContext, IEquipmentsDbContext
    {
        static EquipmentsBusinessContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

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

        //public async Task<IEnumerable<TResult>> FromSql<TResult>(string sql, params object[] parameters) where TResult : class
        //{
        //    using var connection = Database.GetDbConnection();
        //    await connection.OpenAsync();
        //    using NpgsqlCommand command = (NpgsqlCommand)connection.CreateCommand();
        //    command.CommandText = sql;

        //    for (int i = 0; i < parameters.Length; i++)
        //    {
        //        string type = parameters[i].GetType().ToString();
        //        var value = parameters[i];
        //        command.Parameters.Add(new NpgsqlParameter() { Value = value });
        //    }

        //    using var reader = await command.ExecuteReaderAsync();
        //    var result = new List<TResult>();

        //    while (await reader.ReadAsync())
        //    {
        //        var obj = Activator.CreateInstance<TResult>();
        //        var properties = obj.GetType().GetProperties();

        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            var property = properties.FirstOrDefault(p => string.Equals(p.Name, reader.GetName(i), StringComparison.OrdinalIgnoreCase));

        //            if (property != null && reader.IsDBNull(i) == false)
        //            {
        //                var value = reader.GetValue(i);
        //                var propertyType = property.PropertyType;
        //                var convertedValue = Convert.ChangeType(value, propertyType);
        //                property.SetValue(obj, convertedValue);
        //            }
        //        }

        //        result.Add(obj);
        //    }
        //    return result;
        //}


        public async Task<IEnumerable<TResult>> FromSql<TResult>(string sql, object parameters) where TResult : class
        {
            using var connection = Database.GetDbConnection();
            await connection.OpenAsync();

            var result = await connection.QueryAsync<TResult>(sql, parameters);

            return result;
        }
        public async Task<IEnumerable<TResult>> FromSql<TResult>(string sql) where TResult : class
        {
            using var connection = Database.GetDbConnection();
            await connection.OpenAsync();

            var result = await connection.QueryAsync<TResult>(sql);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
            modelBuilder.ApplyConfiguration(new EmployeeRolesConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
