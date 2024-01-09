using AutoMapper;
using FMA.Application.Commands.Tankkaarten.BlockTankkaart;
using FMA.Application.Commands.Tankkaarten.CreateTankkaart;
using FMA.Application.Commands.Tankkaarten.UnblockTankkaart;
using FMA.Application.Commands.Tankkaarten.UpdateTankkaart;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Entities;

namespace FMA.Application.Profiles
{
    public class TankkaartProfile : Profile
    {
        public TankkaartProfile()
        {
            //Mapping
            CreateMap<CreateTankkaartCommand, Tankkaart>(MemberList.Source)
                .ForSourceMember(x => x.Services, x => x.DoNotValidate());

            CreateMap<UpdateTankkaartCommand, Tankkaart>(MemberList.Source);

            //Projections
            CreateProjection<Tankkaart, TankkaartSelectListDTO>();
            CreateProjection<Tankkaart, TankkaartListDTO>();
            CreateProjection<Tankkaart, TankkaartDTO>();
        }
    }
}
