using MediatR;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.Delete
{
    public class DeleteMySqlSampleRequest : IRequest<Result<Unit>>
    {
        public Guid MySqlSampleId { get; set; }

        public DeleteMySqlSampleRequest(Guid mySqlSampleId)
        {
            MySqlSampleId = mySqlSampleId;
        }
    }
}
