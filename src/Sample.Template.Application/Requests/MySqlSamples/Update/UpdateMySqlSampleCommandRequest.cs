using MediatR;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.Update
{
    public class UpdateMySqlSampleCommandRequest : IRequest<Result<Unit>>
    {
        public Guid MySqlSampleId { get; set; }
        public string Name { get; set; }

        public UpdateMySqlSampleCommandRequest(Guid mySqlSampleId, string name)
        {
            MySqlSampleId = mySqlSampleId;
            Name = name;
        }
    }
}
