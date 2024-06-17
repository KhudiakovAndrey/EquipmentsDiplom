using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetAllBySysAdminSQL
    {
        public class ServiceRequestDto : IMapWith<EquipmentServiceRequest>
        {
            public string BrokenEquipmentDescription { get; set; }
            public string Status { get; set; }
            public DateTime LastStatusChangeDate { get; set; }

        }
    }
}
