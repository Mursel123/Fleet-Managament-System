using AutoMapper;
using FMA.Application.DTOs.Garages;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class GarageProfile : Profile
    {
        public GarageProfile()
        {
            //Mapping
            CreateMap<Garage, GarageDTO>();

            //Projections
            CreateProjection<Garage, GarageSelectListDTO>();
        }
    }
}
