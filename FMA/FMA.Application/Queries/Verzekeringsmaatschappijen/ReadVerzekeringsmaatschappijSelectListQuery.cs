using FMA.Application.DTOs.Verzekeringsmaatschappijen;
using MediatR;

namespace FMA.Application.Queries.Verzekeringsmaatschappijen
{
    public record ReadVerzekeringsmaatschappijSelectListQuery : IRequest<List<VerzekeringsmaatschappijSelectListDTO>> { }
}
