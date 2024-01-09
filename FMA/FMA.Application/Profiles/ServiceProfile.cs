using AutoMapper;
using FMA.Application.DTOs.SubDTOS;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            //Mapping
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceVm, Service>(MemberList.Source);
        }
    }
}
