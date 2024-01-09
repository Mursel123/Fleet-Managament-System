using AutoMapper;
using FMA.Application.DTOs.GemeldeSchades;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class GemeldeSchadeProfile : Profile
    {
        public GemeldeSchadeProfile()
        {
            //Mapping
            CreateMap<GemeldeSchade, GemeldeSchadeDTO>().ReverseMap();
            CreateProjection<GemeldeSchade, GemeldeSchadeSelectListDTO>();
        }
    }
}
