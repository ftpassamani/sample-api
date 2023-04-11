using Sample.Template.Domain;

namespace Sample.Template.Application.Services.MySqlSampleRepository
{
    public interface IMySqlSampleRepository
    {
        Task<MySqlSample> CreateAsync(MySqlSample entity, CancellationToken cancellationToken = default);
        Task<MySqlSample> GetAsync(Guid mySqlSampleId, CancellationToken cancellationToken = default);
        Task UpdateAsync(MySqlSample entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid mySqlSampleId, CancellationToken cancellationToken = default);
        Task<IEnumerable<MySqlSample>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
