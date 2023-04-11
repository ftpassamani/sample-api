using AutoMapper;
using MediatR;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.CrossCutting.Result;
using Sample.Template.Domain;

namespace Sample.Template.Application.Requests.MySqlSamples.Create
{
    public class CreateMySqlSampleHandler : IRequestHandler<CreateMySqlSampleCommandRequest, Result<Guid>>
    {
        private readonly IMySqlSampleRepository _mySqlSampleRepository;
        private readonly IMapper _mapper;

        public CreateMySqlSampleHandler(IMySqlSampleRepository mySqlSampleRepository, IMapper mapper)
        {
            _mySqlSampleRepository = mySqlSampleRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateMySqlSampleCommandRequest request, CancellationToken cancellationToken)
        {
            var newMySqlSample = _mapper.Map<MySqlSample>(request);

            var mySqlSample = await _mySqlSampleRepository.CreateAsync(newMySqlSample, cancellationToken);

            return mySqlSample.MySqlSampleId;
        }
    }
}
