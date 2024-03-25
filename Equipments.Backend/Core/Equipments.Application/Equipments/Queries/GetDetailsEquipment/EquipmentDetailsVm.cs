using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Queries.GetDetailsEquipment
{
    public partial class GetDetailsEquipment
    {
        public class EquipmentDetailsVm : IMapWith<Equipment>
        {

            public int IdEquipment { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Fulltitle { get; set; } = string.Empty;
            public bool Isgroup { get; set; }
            public int IdStatusEquipment { get; set; }
            public int IdTypeEquipment { get; set; }

            public IList<InventoryItemDto> InvetoryObjects { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Equipment, EquipmentDetailsVm>()
                    .ForMember(eqDto => eqDto.IdEquipment,
                        opt => opt.MapFrom(eq => eq.IdEquipment))
                    .ForMember(eqDto => eqDto.Title,
                        opt => opt.MapFrom(eq => eq.Title))
                    .ForMember(eqDto => eqDto.Isgroup,
                        opt => opt.MapFrom(eq => eq.Isgroup))
                    .ForMember(eqDto => eqDto.IdStatusEquipment,
                        opt => opt.MapFrom(eq => eq.IdStatusEquipment))
                    .ForMember(eqDto => eqDto.IdTypeEquipment,
                        opt => opt.MapFrom(eq => eq.IdTypeEquipment));
            }
        }
    }
}
