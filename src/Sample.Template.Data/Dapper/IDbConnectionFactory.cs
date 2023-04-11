using System.Data;

namespace Sample.Template.Data.Dapper
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
