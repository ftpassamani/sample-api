using AutoMapper;
using MediatR;
using Sample.Template.Application.Requests.MySqlSamples.Commun;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.CrossCutting.Result;
using static Sample.Template.CrossCutting.Result.Error;

namespace Sample.Template.Application.Requests.MySqlSamples.GetById
{
    public class GetMySqlSampleByIdHandler : IRequestHandler<GetMySqlSampleByIdRequest, Result<MySqlSampleDto>>
    {
        private readonly IMySqlSampleRepository _mySqlSampleRepository;
        private readonly IMapper _mapper;

        public GetMySqlSampleByIdHandler(IMySqlSampleRepository mySqlSampleRepository, IMapper mapper)
        {
            _mySqlSampleRepository = mySqlSampleRepository;
            _mapper = mapper;
        }

        public async Task<Result<MySqlSampleDto>> Handle(GetMySqlSampleByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _mySqlSampleRepository.GetAsync(request.MySqlSampleId, cancellationToken);
            
            if (response == null)
            {
                return CreateNotFound(nameof(response), request.MySqlSampleId);
            }

            var responseDto = _mapper.Map<MySqlSampleDto>(response);

            return responseDto;
        }
    }
}
