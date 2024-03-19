using AutoMapper;
using Equipments.Application.Common.Mappings;
using Equipments.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.WebAPI.Models
{
    public class CreateUserDto : IMapWith<CreateUser.Command>
    {

        public string Userlogin { get; set; }
        public string Userpassword { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUser.Command>()
                .ForMember(userCommand => userCommand.Userlogin,
                    opt => opt.MapFrom(userDto => userDto.Userlogin))
                .ForMember(userCommand => userCommand.Userpassword,
                    opt => opt.MapFrom(userDto => userDto.Userpassword))
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }


    }
}
