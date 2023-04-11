using MediatR;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.Delete
{
    public  class DeleteMySqlSampleHandler : IRequestHandler<DeleteMySqlSampleRequest, Result<Unit>>
    {
        private readonly IMySqlSampleRepository _mySqlSampleRepository;

        public DeleteMySqlSampleHandler(IMySqlSampleRepository mySqlSampleRepository)
        {
            _mySqlSampleRepository = mySqlSampleRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteMySqlSampleRequest request, CancellationToken cancellationToken)
        {
            await _mySqlSampleRepository.DeleteAsync(request.MySqlSampleId, cancellationToken);

            return Unit.Value;
        }
    }
}
