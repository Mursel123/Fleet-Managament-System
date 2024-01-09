using AutoMapper;
using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using FMA.Application.Commands.Chauffeurs.UpdateChauffeur;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Domain.Entities;

namespace FMA.Application.Profiles
{
    public class ChauffeurProfile : Profile
    {
        public ChauffeurProfile()
        {
            //Mapping
            CreateMap<Voertuig, ChauffeurVoertuigDTO>();
            CreateMap<Tankkaart, ChauffeurTankkaartDTO>();


            CreateMap<CreateChauffeurCommand, Chauffeur>(MemberList.Source)
                .ForPath(dest => dest.Adres.Straat, opt => opt.MapFrom(src => src.Straat))
                .ForPath(dest => dest.Adres.Nummer, opt => opt.MapFrom(src => src.Nummer))
                .ForPath(dest => dest.Adres.Bus, opt => opt.MapFrom(src => src.Bus))
                .ForPath(dest => dest.Gemeente.Stad, opt => opt.MapFrom(src => src.Stad))
                .ForPath(dest => dest.Gemeente.Postcode, opt => opt.MapFrom(src => src.Postcode))
                .ForSourceMember(x => x.TankkaartId, x => x.DoNotValidate())
                .ForSourceMember(x => x.GemeenteId, x => x.DoNotValidate());

            CreateMap<UpdateChauffeurCommand, Chauffeur>(MemberList.Source)
                .ForPath(dest => dest.Adres.Straat, opt => opt.MapFrom(src => src.Straat))
                .ForPath(dest => dest.Adres.Nummer, opt => opt.MapFrom(src => src.Nummer))
                .ForPath(dest => dest.Adres.Bus, opt => opt.MapFrom(src => src.Bus))
                .ForPath(dest => dest.Gemeente.Stad, opt => opt.MapFrom(src => src.Stad))
                .ForPath(dest => dest.Gemeente.Postcode, opt => opt.MapFrom(src => src.Postcode))
                .ForSourceMember(x => x.TankkaartId, x => x.DoNotValidate())
                .ForSourceMember(x => x.GemeenteId, x => x.DoNotValidate());

            //Projections
            CreateProjection<Chauffeur, ChauffeurDTO>();
            CreateProjection<Chauffeur, ChauffeurListDTO>();
        }

    }
}
