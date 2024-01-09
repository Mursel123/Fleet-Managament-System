using AutoMapper;
using FMA.Application.Profiles;
using FMA.Domain.Entities;
using FMA.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using FMA.Domain.Enums;
using System.Reflection;
using Microsoft.AspNetCore.SignalR;
using FMA.Application;
using NSubstitute;
using Microsoft.Extensions.Options;
using FMA.Domain.Config;

namespace FMA.Handler.Tests
{
    public class TestFixture 
    {
        private readonly DbContextOptions<FMADbContext> _options;
        private readonly DbConnection _connection;
        public FMADbContext _context { get; private set; }
        public IMapper _mapper { get; private set; }
        public IHubContext<NotificationHub> _hubContext { get; private set; }
        public IOptions<SignalR> _optionsSignalR { get; private set; }
        public TestFixture()
        {
            _connection = new SqliteConnection($"DataSource=:memory:");
            _connection.Open();

            _options = new DbContextOptionsBuilder<FMADbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new FMADbContext(_options);

            var configuration = new MapperConfiguration(cfg =>
            {
                var profiles = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t)));
                cfg.AddMaps(profiles);
            });
            _mapper = configuration.CreateMapper();


            
            _hubContext = Substitute.For<IHubContext<NotificationHub>>();
            //_optionsSignalR = Substitute.For<IOptions<SignalR>>();
            _context.Database.EnsureCreated();

            CreateOptionsSignalR();
            CreateSamples();
        }

        private void CreateOptionsSignalR()
        {
            var methodSubstitute = Substitute.For<Method>(); 
            var hubConfigSubstitute = new HubConfig
            {
                Endpoint = "",
                Method = methodSubstitute
            };

            var signalR = new SignalR
            {
                Hub = hubConfigSubstitute
            };

            _optionsSignalR =  Options.Create(signalR);
        }

        public void CreateSamples()
        {
            _context.ChangeTracker.Clear();
            if (!_context.Chauffeur.Any(x => x.Id == Guid.Parse("3814E788-42BF-410F-84A1-A351F61BDB5F")))
            {
                var chauffeur = new Chauffeur
                {
                    Id = Guid.Parse("3814E788-42BF-410F-84A1-A351F61BDB5F"),
                    Naam = "Koseer",
                    Voornaam = "Mursel",
                    Email = "mursel.koseer@test.com",
                    Geslacht = Geslacht.Man,
                    RijbewijsType = RijbewijsType.B,
                    Tankkaart = null,
                    Geboortedatum = new DateTime(2002, 3, 1),
                    Rijksregisternummer = "02.03.01-001.40",
                   
                };
                _context.Chauffeur.Add(chauffeur);
                _context.SaveChanges();
            }
            if (!_context.Tankkaart.Any(x => x.Id == Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08")))
            {
                var tankkaart = new Tankkaart
                {
                    Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08"),
                    KaartNummer = "0215214852",
                    GeldigheidsDatum = DateTime.Now.AddMonths(6),
                    Pincode = "24563",
                    AuthenticatieType = AuthenticatieType.PinEnKilometerstand,
                    BrandstofType = BrandstofType.Diesel,
                    Services = new(),
                   

                };
                _context.Tankkaart.Add(tankkaart);
                _context.SaveChanges();
            }

            if (!_context.Gemeente.Any(x => x.Id == Guid.Parse("5B6DBD3E-0E5A-4708-9E67-7B9654B6B747")))
            {
                var gemeente = new Gemeente 
                { 
                    Id = Guid.Parse("5B6DBD3E-0E5A-4708-9E67-7B9654B6B747"), 
                    Postcode = "3580", 
                    Stad = "Beringen", 
                     
                };

                _context.Gemeente.Add(gemeente);
                _context.SaveChanges();
            }

        }

    }
}
