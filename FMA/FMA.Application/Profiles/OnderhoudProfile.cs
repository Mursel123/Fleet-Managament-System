using AutoMapper;
using FMA.Application.Commands.Onderhouden.Create;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class OnderhoudProfile : Profile
    {
        public OnderhoudProfile()
        {
            //Mapping
            CreateMap<Onderhoud, OnderhoudDTO>();

            CreateMap<CreateOnderhoudCommand, Onderhoud>(MemberList.Source)
                .ForSourceMember(x => x.VoertuigId, x => x.DoNotValidate())
                .ForSourceMember(x => x.FileName, x => x.DoNotValidate())
                .ForSourceMember(x => x.FileData, x => x.DoNotValidate())
                .ForSourceMember(x => x.BestandType, x => x.DoNotValidate())
                .ForSourceMember(x => x.AanvraagId, x => x.DoNotValidate())
                .ForSourceMember(x => x.GarageId, x => x.DoNotValidate());

        }
    }
}
