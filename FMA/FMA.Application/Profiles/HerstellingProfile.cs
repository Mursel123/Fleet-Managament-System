using AutoMapper;
using FMA.Application.Commands.Herstellingen.Create;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class HerstellingProfile : Profile
    {
        public HerstellingProfile()
        {
            //Mapping
            CreateMap<Herstelling, HerstellingDTO>();
            CreateMap<CreateHerstellingCommand, Herstelling>(MemberList.Source)
                .ForSourceMember(x => x.AanvraagId, x => x.DoNotValidate())
                .ForSourceMember(x => x.VoertuigId, x => x.DoNotValidate())
                .ForSourceMember(x => x.VerzekeringsmaatschappijId, x => x.DoNotValidate())
                .ForSourceMember(x => x.GemeldeSchadeId, x => x.DoNotValidate());

            CreateMap<HerstellingDocumentDTO, Document>(MemberList.Source);
        }
    }
}
