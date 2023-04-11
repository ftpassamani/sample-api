using AutoMapper;
using MediatR;
using Sample.Template.Application.Requests.MySqlSamples.Commun;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Application.Requests.MySqlSamples.GetAll
{
    public class GetAllMySqlSamplesHandler : IRequestHandler<GetAllMySqlSamplesRequest, Result<IEnumerable<MySqlSampleDto>>>
    {
        private readonly IMySqlSampleRepository _mySqlSampleRepository;
        private readonly IMapper _mapper;

        public GetAllMySqlSamplesHandler(IMySqlSampleRepository mySqlSampleRepository, IMapper mapper)
        {
            _mySqlSampleRepository = mySqlSampleRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<MySqlSampleDto>>> Handle(GetAllMySqlSamplesRequest request, CancellationToken cancellationToken)
        {
            var response = await _mySqlSampleRepository.GetAllAsync(cancellationToken);

            var responseDto = _mapper.Map<List<MySqlSampleDto>>(response);

            return responseDto;
        }
    }
}
