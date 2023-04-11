using MediatR;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.Create
{
    public class CreateMySqlSampleCommandRequest : IRequest<Result<Guid>>
    {
        public Guid MySqlSampleId { get; set; }
        public string? Name { get; set; }
    }
}
