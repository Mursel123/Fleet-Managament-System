using AutoMapper;
using FMA.Application.DTOs.SubDTOS;
using FMA.Application.DTOs.Verzekeringsmaatschappijen;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class VerzekeringsmaatschappijProfile : Profile
    {
        public VerzekeringsmaatschappijProfile()
        {
            //Mapping
            CreateMap<Verzekeringsmaatschappij, VerzekeringsmaatschappijDTO>().ReverseMap();
            CreateProjection<Verzekeringsmaatschappij, VerzekeringsmaatschappijSelectListDTO>();
        }
    }
}
