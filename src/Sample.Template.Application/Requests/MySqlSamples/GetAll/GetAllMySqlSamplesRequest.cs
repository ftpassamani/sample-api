using MediatR;
using Sample.Template.Application.Requests.MySqlSamples.Commun;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.GetAll
{
    public class GetAllMySqlSamplesRequest : IRequest<Result<IEnumerable<MySqlSampleDto>>>
    {
    }
}
