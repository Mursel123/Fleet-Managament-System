using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace FMA.Configuration.Tests
{
    public class AutoMapperTests 
    {
        private readonly IMapper _mapper;
        public AutoMapperTests()
        {
            var _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                var profiles = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null))
                    .Select(t => (Profile)Activator.CreateInstance(t));

                cfg.AddProfiles(profiles);
            });

            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void MapperConfiguration_Should_Pass()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
