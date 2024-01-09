using AutoMapper;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class AdresProfile : Profile
    {
        public AdresProfile()
        {
            //Mapping
            CreateMap<Adres, AdresDTO>().ReverseMap();
        }
    }
}
