using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;

namespace Equipments.Application.ProblemTypes
{
    public class ProblemTypeDto : IMapWith<ProblemType>
    {
        public int Id { get; set; }
        public int IdequipmentType { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
        }
    }
}
