using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.EquipmentsServiceRequest.Quries
{
    public partial class GetPageServiceReqeust
    {
        public class ServiceRequestVM : IMapWith<EquipmentServiceRequest>
        {
            public Guid ID { get; set; }
            public void Mapping(Profile profile)
            {

            }

        }
    }
}
