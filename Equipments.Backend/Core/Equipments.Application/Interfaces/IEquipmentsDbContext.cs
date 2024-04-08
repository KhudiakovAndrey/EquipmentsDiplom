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
        DbSet<AssignedOffice> AssignedOffices { get; set; }
        DbSet<CommercialOffer> CommercialOffers { get; set; }
        DbSet<CommercialOrganization> CommercialOrganizations { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EquipmentPurchaseRequest> EquipmentPurchaseRequests { get; set; }
        DbSet<EquipmentServiceRequest> EquipmentServiceRequests { get; set; }
        DbSet<EquipmentType> EquipmentTypes { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<ProblemType> ProblemTypes { get; set; }
        DbSet<PurchasedEquipment> PurchasedEquipments { get; set; }
        DbSet<RequestComment> RequestComments { get; set; }
        DbSet<RequestStatus> RequestStatuses { get; set; }
        DbSet<RequestStatusChange> RequestStatusChanges { get; set; }


        Task<bool> CheckConnectionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
