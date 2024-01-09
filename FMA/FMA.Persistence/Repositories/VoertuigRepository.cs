using Dapper;
using FMA.Contracts.Persistence;
using FMA.Domain.Config;
using FMA.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace FMA.Persistence.Repositories
{
    public class VoertuigRepository : IVoertuigRepository, IBaseRepository<Voertuig>
    {
        private const string _voertuigTableName = "Voertuig";
        private readonly string _optionsConnection;

        public VoertuigRepository(IOptions<Connection> optionsConnection)
        {
            _optionsConnection = optionsConnection.Value.FleetManagementConnectionString;
        }

        public async Task AddAsync(Voertuig voertuig, CancellationToken ct)
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);

            var sql = @$"INSERT INTO {_voertuigTableName} (Chassisnummer, StartLeasing, EersteInschrijving, LooptijdLeasing, WagenType, BrandstofType) 
                        VALUES (@Chassisnummer, @StartLeasing, @EersteInschrijving, @LooptijdLeasing, @WagenType, @BrandstofType);
                        SELECT LAST_INSERT_ID();";
            
            await _dbConnection.QuerySingleAsync<Guid>(new CommandDefinition(sql, voertuig, cancellationToken: ct));
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);
            var sql = @$"DELETE FROM {_voertuigTableName} WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(new CommandDefinition(sql, new { Id = id }, cancellationToken: ct));
        }

        public async Task<T> GetByIdAsync<T>(Guid id, CancellationToken ct) where T : class
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);
            var sql = @$"SELECT * FROM {_voertuigTableName} WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(new CommandDefinition(sql, new {Id = id}, cancellationToken: ct));
        }

        public async Task<List<T>> ListAllAsync<T>(CancellationToken ct) where T : class
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);
            var sql = @$"SELECT Id, Chassisnummer, StartLeasing, EersteInschrijving, LooptijdLeasing, WagenType, BrandstofType FROM {_voertuigTableName}";
            return (List<T>)await _dbConnection.QueryAsync<T>(new CommandDefinition(sql, cancellationToken: ct));
        }

        public async Task<List<T>> ReadVoertuigenSelectListAsync<T>(CancellationToken ct) where T : class, IVoertuigSelectList
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);
            var sql = @$"SELECT Id, Chassisnummer FROM {_voertuigTableName}";
            return (List<T>)await _dbConnection.QueryAsync<T>(new CommandDefinition(sql, cancellationToken: ct));
        }

        public async Task UpdateAsync(Voertuig voertuig, CancellationToken ct)
        {
            using IDbConnection _dbConnection = new SqlConnection(_optionsConnection);
            var sql = @$"UPDATE {_voertuigTableName} SET Chassisnummer = @Chassisnummer, StartLeasing = @StartLeasing, EersteInschrijving = @EersteInschrijving, 
                        LooptijdLeasing = @LooptijdLeasing, WagenType = @WagenType, BrandstofType = @BrandstofType 
                        WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(new CommandDefinition(sql, voertuig, cancellationToken: ct));
        }
    }
}
