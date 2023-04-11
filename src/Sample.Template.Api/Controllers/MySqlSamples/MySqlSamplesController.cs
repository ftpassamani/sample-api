using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Template.Application.Requests.MySqlSamples.Commun;
using Sample.Template.Application.Requests.MySqlSamples.Create;
using Sample.Template.Application.Requests.MySqlSamples.Delete;
using Sample.Template.Application.Requests.MySqlSamples.GetAll;
using Sample.Template.Application.Requests.MySqlSamples.GetById;
using Sample.Template.Application.Requests.MySqlSamples.Update;

namespace Sample.Template.Api.Controllers.MySqlSamples
{
    [Route("v1/[controller]")]
    public class MySqlSamplesController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<MySqlSamplesController> _logger;

        public MySqlSamplesController(IMediator mediator, IMapper mapper, ILogger<MySqlSamplesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MySqlSampleDto>>> GetAllMySqlSamplesAsync()
        {
            _logger.LogInformation("Endpoint GetAllMySqlSamplesAsync successful.");

            var request = new GetAllMySqlSamplesRequest();
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMySqlSampleAsync([FromBody] CreateMySqlSampleRequest request)
        {
            _logger.LogInformation("Endpoint CreateMySqlSampleAsync successful.");

            var command = _mapper.Map<CreateMySqlSampleCommandRequest>(request);
            var response = await _mediator.Send(command);

            return Created(response, string.Empty, new { mySqlSampleId = response.Value });
        }

        [HttpGet("{mySqlSampleId}")]
        public async Task<ActionResult<MySqlSampleDto>> GetMySqlSampleByIdAsync([FromRoute] Guid mySqlSampleId)
        {
            _logger.LogInformation("Endpoint GetMySqlSampleById successful.");

            var request = new GetMySqlSampleByIdRequest(mySqlSampleId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("{mySqlSampleId}")]
        public async Task<ActionResult> UpdateMySqlSampleAsync([FromRoute] Guid mySqlSampleId, [FromBody] UpdateMySqlSampleRequest request)
        {
            _logger.LogInformation("Endpoint UpdateMySqlSampleAsync successful.");

            var command = new UpdateMySqlSampleCommandRequest(mySqlSampleId, request.Name);
            var result = await _mediator.Send(command);

            return NoContent(result);
        }

        [HttpDelete("{mySqlSampleId}")]
        public async Task<ActionResult> DeleteMySqlSampleAsync([FromRoute] Guid mySqlSampleId)
        {
            _logger.LogInformation("Endpoint DeleteMySqlSampleAsync successful.");

            var request = new DeleteMySqlSampleRequest(mySqlSampleId);
            var result = await _mediator.Send(request);

            return NoContent(result);
        }
    }
}
