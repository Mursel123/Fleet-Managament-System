using AutoMapper;
using FMA.Application.Commands.Aanvragen.Create;
using FMA.Application.Commands.Aanvragen.Update;
using FMA.Application.Commands.Aanvragen.UpdateStatus;
using FMA.Application.DTOs.Aanvragen;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;

namespace FMA.Application.Profiles
{
    public class AanvraagProfile : Profile
    {
        public AanvraagProfile()
        {
            //Mapping
            CreateMap<Chauffeur, AanvraagChauffeurDTO>();
            CreateMap<Voertuig, AanvraagVoertuigDTO>();
            CreateMap<Onderhoud, AanvraagOnderhoudDTO>();
            CreateMap<Herstelling, AanvraagHerstellingDTO>();
            CreateMap<Document, AanvraagDocumentDTO>();
            CreateMap<GemeldeSchade, AanvraagGemeldeSchadeDTO>();

            CreateMap<UpdateAanvraagStatusCommand, Aanvraag>(MemberList.Source);
            CreateMap<CreateAanvraagCommand, Aanvraag>(MemberList.Source)
                .ForSourceMember(x => x.Email, x => x.DoNotValidate())
                .ForSourceMember(x => x.VoertuigId, x => x.DoNotValidate());

            //Projections
            CreateProjection<Aanvraag, AanvraagDTO>();
            CreateProjection<Aanvraag, AanvraagNotificationListDTO>();
        }
    }
}
