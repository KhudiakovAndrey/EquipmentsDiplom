using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentPurchaseRequests.Queries
{
    public partial class GetAllPurchaseRequest
    {
        public class PurchaseRequestItemVm : IMapWith<EquipmentPurchaseRequest>
        {
            public Guid ID { get; set; }
            public Guid IDSystemAdministration { get; set; }
            public string PurchaseReason { get; set; } = string.Empty;
            public DateTime CreationDate { get; set; }
            public string PurchaseDeadline { get; set; } = string.Empty;
            public void Mapping(Profile profile)
            {
                profile.CreateMap<EquipmentPurchaseRequest, PurchaseRequestItemVm>()
                    .ForMember(vm => vm.ID,
                        opt => opt.MapFrom(entity => entity.Id))
                    .ForMember(vm => vm.IDSystemAdministration,
                        opt => opt.MapFrom(entity => entity.IdsystemAdministrator))
                    .ForMember(vm => vm.PurchaseReason,
                        opt => opt.MapFrom(entity => entity.PurchaseReason))
                    .ForMember(vm => vm.CreationDate,
                        opt => opt.MapFrom(entity => entity.CreationDate))
                    .ForMember(vm => vm.PurchaseDeadline,
                        opt => opt.MapFrom(entity => entity.PurchaseDeadline));
            }
        }
    }
}
