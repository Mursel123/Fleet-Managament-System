﻿using AutoMapper;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class HerstellingTypeProfile : Profile
    {
        public HerstellingTypeProfile()
        {
            CreateMap<HerstellingType, HerstellingTypeDTO>();
        }
    }
}
