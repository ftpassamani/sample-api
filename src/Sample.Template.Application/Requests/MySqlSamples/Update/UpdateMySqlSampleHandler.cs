using AutoMapper;
using MediatR;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.CrossCutting.Result;
using Sample.Template.Domain;
using static Sample.Template.CrossCutting.Result.Error;

namespace Sample.Template.Application.Requests.MySqlSamples.Update
{
    public class UpdateMySqlSampleHandler : IRequestHandler<UpdateMySqlSampleCommandRequest, Result<Unit>>
    {
        private readonly IMySqlSampleRepository _mySqlSampleRepository;
        private readonly IMapper _mapper;

        public UpdateMySqlSampleHandler(IMySqlSampleRepository mySqlSampleRepository, IMapper mapper)
        {
            _mySqlSampleRepository = mySqlSampleRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateMySqlSampleCommandRequest request, CancellationToken cancellationToken)
        {
            var mySqlSample = await _mySqlSampleRepository.GetAsync(request.MySqlSampleId, cancellationToken);

            if (mySqlSample == null)
            {
                return CreateNotFound(nameof(MySqlSample), request.MySqlSampleId);
            }

            mySqlSample = _mapper.Map<MySqlSample>(request);

            await _mySqlSampleRepository.UpdateAsync(mySqlSample, cancellationToken);

            return Unit.Value;
        }
    }
}
