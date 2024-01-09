using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using MediatR;

namespace FMA.Application.Commands.Gemeentes.Create
{
    public class CreateGemeenteCommand : IRequest<Guid?>
    {
        public string Postcode { get; set; } = string.Empty;
        public string Stad { get; set; } = string.Empty;
        public CreateChauffeurCommand ChauffeurCommand { get; set; }
    }
}
