using AutoMapper;
using FMA.Application.Commands.Gemeentes.Create;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;

namespace FMA.Application.Profiles
{
    public class GemeenteProfile : Profile
    {
        public GemeenteProfile()
        {
            //Mapping
            CreateMap<Gemeente, GemeenteDTO>();
            CreateMap<CreateGemeenteCommand, Gemeente>(MemberList.Source)
                .ForSourceMember(x => x.ChauffeurCommand, x => x.DoNotValidate());
        }
    }
}
