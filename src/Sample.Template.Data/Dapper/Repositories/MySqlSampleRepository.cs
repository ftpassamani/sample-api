using Dapper;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.Domain;

namespace Sample.Template.Data.Dapper.Repositories
{
    public class MySqlSampleRepository : IMySqlSampleRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public MySqlSampleRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<MySqlSample> CreateAsync(MySqlSample entity, CancellationToken cancellationToken = default)
        {
            using var connection = _dbConnectionFactory.Create();
            const string sql = "INSERT INTO MySqlSample (MySqlSampleId, Name) VALUES (@MySqlSampleId, @Name);";
            
            await connection.ExecuteAsync(new CommandDefinition( sql, new { MySqlSampleId = entity.MySqlSampleId, Name = entity.Name }));
            return entity;
        }

        public async Task DeleteAsync(Guid mySqlSampleId, CancellationToken cancellationToken = default)
        {
            using var connection = _dbConnectionFactory.Create();
            const string sql = "DELETE FROM MySqlSample WHERE MySqlSampleId = @MySqlSampleId";
            await connection.ExecuteAsync(sql, new { MySqlSampleId = mySqlSampleId });
        }

        public async Task<IEnumerable<MySqlSample>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _dbConnectionFactory.Create();
            const string sql = "SELECT MySqlSampleId, Name FROM MySqlSample;";

            var query = await connection.QueryAsync<MySqlSample>(sql);
            return query.ToList();
        }

        public async Task<MySqlSample> GetAsync(Guid mySqlSampleId, CancellationToken cancellationToken = default)
        {
            using var connection = _dbConnectionFactory.Create();
            const string sql = "SELECT MySqlSampleId, Name FROM MySqlSample WHERE MySqlSampleId = @MySqlSampleId;";
            return await connection.QueryFirstOrDefaultAsync<MySqlSample>(sql, new { MySqlSampleId = mySqlSampleId });
        }

        public async Task UpdateAsync(MySqlSample entity, CancellationToken cancellationToken = default)
        {
            using var connection = _dbConnectionFactory.Create();
            const string sql = "UPDATE MySqlSample SET Name = @Name WHERE MySqlSampleId = @MySqlSampleId";
            await connection.ExecuteAsync(sql, new { Name = entity.Name, MySqlSampleId = entity.MySqlSampleId });
        }
    }
}
