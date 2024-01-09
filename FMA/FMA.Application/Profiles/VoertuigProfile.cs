using AutoMapper;
using FMA.Application.DTOs.Voertuigen;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class VoertuigProfile : Profile
    {
        public VoertuigProfile()
        {
            //Projections
            CreateProjection<Voertuig, VoertuigDTO>();
            CreateProjection<Voertuig, VoertuigListDTO>();
        }
    }
}
