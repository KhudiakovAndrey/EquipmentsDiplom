using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries.GetUsers
{
    public class UserVm : IMapWith<User>
    {
        public int Iduser { get; set; }
        public string Userlogin { get; set; }
        public string Email { get; set; }
        public DateTime? Datelastlogin { get; set; }
        public DateTime? Dateregistration { get; set; }
        public bool Isregemailactive { get; set; }
        public bool Isactive { get; set; }
        public int? Idworker { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(userVm => userVm.Iduser,
                    opt => opt.MapFrom(user => user.Iduser))
                .ForMember(userVm => userVm.Userlogin,
                    opt => opt.MapFrom(user => user.Userlogin))
                .ForMember(userVm => userVm.Datelastlogin,
                    opt => opt.MapFrom(user => user.Datelastlogin))
                .ForMember(userVm => userVm.Dateregistration,
                    opt => opt.MapFrom(user => user.Dateregistration))
                .ForMember(userVm => userVm.Isregemailactive,
                    opt => opt.MapFrom(user => user.Isregemailactive))
                .ForMember(userVm => userVm.Isactive,
                    opt => opt.MapFrom(user => user.Isactive))
                .ForMember(userVm => userVm.Idworker,
                    opt => opt.MapFrom(user => user.Idworker));
        }
    }
}
