using NetArchTest.Rules;


namespace FMA.Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "FMA.Domain";
        private const string ApplicationNamespace = "FMA.Application";
        private const string PersistenceNamespace = "FMA.Persistence";
        private const string StartupNamespace = "FMA.Startup";
        private const string ApiWriteNamespace = "FMA.Api.Write";
        private const string ApiReadNamespace = "FMA.Api.Read";
        private const string ContractsNamespace = "FMA.Contracts";
        private const string IdpNamespace = "FMA.IDP";
        private const string BlazorNamespace = "FMA.UI.Blazor";
        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Domain.Entities.Aanvraag).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                PersistenceNamespace,
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                ContractsNamespace,
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void Contracts_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Domain.Entities.Aanvraag).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                PersistenceNamespace,
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Application.ApplicationServiceRegistration).Assembly;

            var otherProjects = new[]
            {
                PersistenceNamespace,
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Persistence.PersistenceServiceRegistration).Assembly;

            var otherProjects = new[]
            {
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void Startup_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Startup.StartupExtensions).Assembly;

            var otherProjects = new[]
            {
                ApiReadNamespace,
                ApiWriteNamespace,
                IdpNamespace,
                BlazorNamespace

            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void ReadApi_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Api.Read.Controllers.AanvraagController).Assembly;

            var otherProjects = new[]
            {
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void WriteApi_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(Api.Write.Controllers.AanvraagController).Assembly;

            var otherProjects = new[]
            {
                IdpNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void IDP_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(IDP.Config).Assembly;

            var otherProjects = new[]
            {
                DomainNamespace,
                ApplicationNamespace,
                PersistenceNamespace,
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                ContractsNamespace,
                BlazorNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }

        [Fact]
        public void Blazor_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Given
            var assembly = typeof(UI.Blazor.App).Assembly;

            var otherProjects = new[]
            {
                DomainNamespace,
                ApplicationNamespace,
                PersistenceNamespace,
                StartupNamespace,
                ApiWriteNamespace,
                ApiReadNamespace,
                ContractsNamespace,
                IdpNamespace
            };

            //When
            var testResult = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult().IsSuccessful;

            //Then
            Assert.True(testResult);
        }
    }
}
