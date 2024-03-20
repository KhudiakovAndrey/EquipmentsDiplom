using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Application.Users.Queries
{

    public class UserVm : IMapWith<AppUser>
    {
        public int Iduser { get; set; }
        public string Userlogin { get; set; }
        public string Email { get; set; }
        public DateTime? Datelastlogin { get; set; }
        public DateTime? Dateregistration { get; set; }
        public bool Isregemailactive { get; set; }
        public bool Isactive { get; set; }
        public int? Idworker { get; set; }
        public Guid RowGuid { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, UserVm>()
                .ForMember(userVm => userVm.Iduser,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Userlogin,
                    opt => opt.MapFrom(user => user.UserName))
                .ForMember(userVm => userVm.Datelastlogin,
                    opt => opt.MapFrom(user => user.LastLoginDate))
                .ForMember(userVm => userVm.Dateregistration,
                    opt => opt.MapFrom(user => user.RegistrationDate))
                .ForMember(userVm => userVm.Isregemailactive,
                    opt => opt.MapFrom(user => user.EmailConfirmed))
                .ForMember(userVm => userVm.Isactive,
                    opt => opt.MapFrom(user => user.LockoutEnabled))
                .ForMember(userVm => userVm.Idworker,
                    opt => opt.MapFrom(user => user.WorkerId));
        }
    }

}
