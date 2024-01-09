using MediatR;

namespace FMA.Application.Commands.Chauffeurs.ActiveChauffeur
{
    public class ActiveChauffeurCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
