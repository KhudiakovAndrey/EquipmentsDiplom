using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Interfaces
{
    public interface IEquipmentsDbContext
    {
        DbSet<Act> Acts { get; set; }
        DbSet<ActsAcceptEquipment> ActsAcceptEquipments { get; set; }
        DbSet<ActsAddResource> ActsAddResources { get; set; }
        DbSet<ActsDeleteEquipment> ActsDeleteEquipments { get; set; }
        DbSet<ActsDeleteResource> ActsDeleteResources { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<EqCustodiansOffice> EqCustodiansOffices { get; set; }
        DbSet<Equipment> Equipments { get; set; }
        DbSet<EquipmentCustodian> EquipmentCustodians { get; set; }
        DbSet<EquipmentResource> EquipmentResources { get; set; }
        DbSet<InventoryObject> InventoryObjects { get; set; }
        DbSet<OfficeAssigment> OfficeAssigments { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<ProgressServiceRequest> ProgressServiceRequests { get; set; }
        DbSet<ServiceRequest> ServiceRequests { get; set; }
        DbSet<StatusEquipment> StatusEquipments { get; set; }
        DbSet<StatusRequest> StatusRequests { get; set; }
        DbSet<TechnicalSupport> TechnicalSupports { get; set; }
        DbSet<TypeEquipment> TypeEquipments { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<Token> Tokens { get; set; }
        DbSet<AppUser> AppUsers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
