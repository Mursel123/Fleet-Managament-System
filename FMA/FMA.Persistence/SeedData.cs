using FMA.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FMA.Domain.Enums;
using System.Text;

namespace FMA.Persistence
{
    public class SeedData
    {
        private static FMADbContext _context;
        public async static Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<FMADbContext>();

            #region Data
            
            var gemeente = new Gemeente { Id = Guid.NewGuid(), Postcode = "3580", Stad = "Beringen"};
            var adres = new Adres() { Straat = "Waterstraat", Nummer = "50", Bus = "7B"};
            var verzekeringsmaatschappij = new Verzekeringsmaatschappij { Id = Guid.NewGuid(), Referentienummer = "1805", Adres = adres, Gemeente = gemeente };

            var service1 = new Service {Id = Guid.NewGuid(), Type = "Fuel" };
            var service2 = new Service {Id = Guid.NewGuid(), Type = "Shop" };
            var services = new List<Service> { service1, service2 };

            var tankkaart = new Tankkaart
            {
                Id = Guid.NewGuid(),
                KaartNummer = "0215214852",
                GeldigheidsDatum = DateTime.Now.AddMonths(6),
                Pincode = "24563",
                AuthenticatieType = AuthenticatieType.PinEnKilometerstand,
                BrandstofType = BrandstofType.Benzine,
                Services = services,


            };
            var nummerplaat = new Nummerplaat { Id = Guid.NewGuid(), IsActief = true, Beschrijving = "1-EKP-859", Datum = DateTime.Now };
            var nummerplaaten = new List<Nummerplaat> { nummerplaat };
            var voertuig = new Voertuig
            {
                Id = Guid.NewGuid(),
                WagenType = WagenType.Personen,
                Chassisnummer = "ZFDFZEZE8554A",
                StartLeasing = DateTime.Now,
                EersteInschrijving = DateTime.Now,
                BrandstofType = BrandstofType.Benzine,
                LooptijdLeasing = DateTime.Now.AddMonths(6),
                Nummerplaten = nummerplaaten,
               


            };
            var kilometerstand = new Kilometerstand {Id = Guid.NewGuid(), Voertuig = voertuig, Stand = "5000" };
            var voertuigen = new List<Voertuig> { voertuig };

            
            var chauffeur = new Chauffeur
            {
                Id = Guid.NewGuid(),
                Naam = "Koseer",
                Voornaam = "Mursel",
                Email = "mursel.koseer@test.com",
                Geslacht = Geslacht.Man,
                RijbewijsType = RijbewijsType.B,
                Tankkaart = tankkaart,
                Adres = adres,
                Gemeente = gemeente,
                Voertuigen = voertuigen,
                Geboortedatum = new DateTime(2001, 3, 1),
                Rijksregisternummer = "93.05.18-223.61",

            };
            var gemeldeSchade = new GemeldeSchade
            {
                Id = Guid.NewGuid(),
                Chauffeur = chauffeur,
                DatumMelding = DateTime.Now,
                DatumSchade = DateTime.Now,
                Schade = "Voorbumper krassen",
                Voertuig = voertuig,


            };
            var herstelling = new Herstelling
            {
                Id = Guid.NewGuid(),
                DatumUitvoering = DateTime.Now,
                Verzekeringsmaatschappij = verzekeringsmaatschappij,
                GemeldeSchade = gemeldeSchade,
                Kostprijs = 18960,
                Voertuig = voertuig,
                Documenten = new()


            };
            var garage = new Garage { Id = Guid.NewGuid(), Naam = "Cardoen Geel", Adres = adres, Gemeente = gemeente };
            var documentFactuur = new Document
            {
                Id = Guid.NewGuid(),
                BestandType = BestandType.PDF,
                FileData = Encoding.UTF8.GetBytes("Test Pdf"),
                FileName = "Test.pdf",
                Herstelling = herstelling,

            };
            var onderhoud = new Onderhoud
            {
                Id = Guid.NewGuid(),
                Voertuig = voertuig,
                DatumUitvoering = DateTime.Now,
                Kostprijs = 1085,
                Garage = garage,
                Document = documentFactuur,
                UitgevoerdeWerken = "Werken aan de bumper",


            };
            var aanvraagOnderhoud = new Aanvraag
            {
                Id = Guid.NewGuid(),
                Voertuig = voertuig,
                Chauffeur = chauffeur,
                Beschrijving = "Onderhoud aanvragen",
                AanvraagType = AanvraagType.Onderhoud,
                StatusType = StatusType.Goedgekeurd,
                Onderhoud = onderhoud
                

            };
            
            var aanvraagHerstelling = new Aanvraag
            {
                Id = Guid.NewGuid(),
                Voertuig = voertuig,
                Chauffeur = chauffeur,
                Beschrijving = "Tankkaart aanvragen",
                AanvraagType = AanvraagType.Herstelling,
                StatusType = StatusType.Goedgekeurd,
                Herstelling = herstelling


            };
            

            var herstellingType = new HerstellingType {Id = Guid.NewGuid(), Type = "Bumper repareren" };
            
            
            
            var inspectieverslag = new Inspectieverslag
            {
                Id = Guid.NewGuid(),
                Chauffeur = chauffeur,
                DatumUitvoering = DateTime.Now,
                ChauffeurAanwezig = true,
                TotaalKost = 18960,
                Verslag = "Dit is de verslag",
                Voertuig = voertuig,
               

            };
            var geinspecteerdeSchade = new GeinspecteerdeSchade
            {
                Id = Guid.NewGuid(),
                Inspectieverslag = inspectieverslag,
                Onderdeel = "Bumper",
                Schade = "Voorbumper krassen",
                HerstellingType = herstellingType,
                Kostprijs = 18960,
                GemeldeSchade = gemeldeSchade,
                

            };
           

            #endregion

            if (!_context.Gemeente.Any())
            {
                await _context.Gemeente.AddAsync(gemeente);
                await _context.SaveChangesAsync();
            }

            if (!_context.Verzekeringsmaatschappij.Any())
            {
                await _context.Verzekeringsmaatschappij.AddAsync(verzekeringsmaatschappij);
                await _context.SaveChangesAsync();
            }
            

            if (!_context.Tankkaart.Any())
            {
                await _context.Tankkaart.AddAsync(tankkaart);
                await _context.SaveChangesAsync();
            }

            if (!_context.Nummerplaat.Any())
            {
                await _context.Nummerplaat.AddAsync(nummerplaat);
                await _context.SaveChangesAsync();
            }

            if (!_context.Voertuig.Any())
            {
                await _context.Voertuig.AddAsync(voertuig);
                await _context.SaveChangesAsync();
            }

            if (!_context.Kilometerstand.Any())
            {
                await _context.Kilometerstand.AddAsync(kilometerstand);
                await _context.SaveChangesAsync();
            }

            if (!_context.Chauffeur.Any())
            {
                await _context.Chauffeur.AddAsync(chauffeur);
                await _context.SaveChangesAsync();
            }
            if (!_context.GemeldeSchade.Any())
            {
                await _context.GemeldeSchade.AddAsync(gemeldeSchade);
                await _context.SaveChangesAsync();
            }
            if (!_context.Garage.Any())
            {
                await _context.Garage.AddAsync(garage);
                await _context.SaveChangesAsync();
            }

            if (!_context.Document.Any())
            {
                await _context.Document.AddAsync(documentFactuur);
                await _context.SaveChangesAsync();
            }
            if (!_context.Onderhoud.Any())
            {
                await _context.Onderhoud.AddAsync(onderhoud);
                await _context.SaveChangesAsync();
            }
            if (!_context.Herstelling.Any())
            {
                await _context.Herstelling.AddAsync(herstelling);
                await _context.SaveChangesAsync();
            }

            if (!_context.Aanvraag.Any())
            {
                await _context.Aanvraag.AddRangeAsync(aanvraagHerstelling, aanvraagOnderhoud);
                await _context.SaveChangesAsync();
            }

            

            if (!_context.HerstellingType.Any())
            {
                await _context.HerstellingType.AddAsync(herstellingType);
                await _context.SaveChangesAsync();
            }
            

            if (!_context.Inspectieverslag.Any())
            {
                await _context.Inspectieverslag.AddAsync(inspectieverslag);
                await _context.SaveChangesAsync();
            }

            if (!_context.GeinspecteerdeSchade.Any())
            {
                await _context.GeinspecteerdeSchade.AddAsync(geinspecteerdeSchade);
                await _context.SaveChangesAsync();
            }

            
            
        }
    }
}
