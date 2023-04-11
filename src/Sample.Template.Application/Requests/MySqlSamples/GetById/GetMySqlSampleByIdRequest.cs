using MediatR;
using Sample.Template.Application.Requests.MySqlSamples.Commun;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.GetById
{
    public class GetMySqlSampleByIdRequest : IRequest<Result<MySqlSampleDto>>
    {
        public Guid MySqlSampleId { get; set; }

        public GetMySqlSampleByIdRequest(Guid mySqlSampleId)
        {
            MySqlSampleId = mySqlSampleId;
        }
    }
}
