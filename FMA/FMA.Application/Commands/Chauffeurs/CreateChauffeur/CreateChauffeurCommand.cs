﻿using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;

namespace FMA.Application.Commands.Chauffeurs.CreateChauffeur
{
    public class CreateChauffeurCommand : IRequest<Guid>
    {
        public string Naam { get; set; } = string.Empty;
        public string Voornaam { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Geboortedatum { get; set; }
        public string Rijksregisternummer { get; set; } = string.Empty;
        public bool IsActief { get; set; } = true;
        public Guid? GemeenteId { get; set; }
        public Guid? TankkaartId { get; set; }
        public string Straat { get; set; } = string.Empty;
        public string Nummer { get; set; } = string.Empty;
        public string Bus { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Stad { get; set; } = string.Empty;
        public RijbewijsType? RijbewijsType { get; set; }
        public Geslacht Geslacht { get; set; }

    }
}
