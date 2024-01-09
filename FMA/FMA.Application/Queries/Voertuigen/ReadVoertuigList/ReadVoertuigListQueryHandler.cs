using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Voertuigen;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FMA.Domain.Entities;

namespace FMA.Application.Queries.Voertuigen.ReadVoertuigList
{
    public class ReadVoertuigListQueryHandler : IRequestHandler<ReadVoertuigListQuery, List<VoertuigListDTO>>
    {
        private readonly IBaseRepository<Voertuig> _baseRepo;

        public ReadVoertuigListQueryHandler(IBaseRepository<Voertuig> baseRepo)
        {
            _baseRepo = baseRepo;
        }
        public async Task<List<VoertuigListDTO>> Handle(ReadVoertuigListQuery request, CancellationToken ct)
        {
            return await _baseRepo.ListAllAsync<VoertuigListDTO>(ct);

        }
    }
}
