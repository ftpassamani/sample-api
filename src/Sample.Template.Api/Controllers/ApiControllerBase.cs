using Microsoft.AspNetCore.Mvc;
using Sample.Template.CrossCutting.Result;

namespace Sample.Template.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public ActionResult Created<T>(Result<T> result, string uri, object value) =>
            result.IsSuccess
                ? Created(uri, value)
                : HandleError(result);
        public ActionResult NoContent<T>(Result<T> result) =>
            result.IsSuccess
                ? NoContent()
                : HandleError(result);

        public ActionResult Ok<T>(Result<T> result) =>
            result.IsSuccess
                ? Ok(result.Value)
                : HandleError(result);

        private ActionResult HandleError<T>(Result<T> result) =>
            result.Error.Type switch
            {
                ErrorType.NotFound => NotFound(ProblemDetailsFactory.CreateProblemDetails(HttpContext,
                    StatusCodes.Status404NotFound,
                    "The specified resource was not found.",
                    detail: result.Error.Message)),
                _ => throw new NotImplementedException($"Handle for the ErrorType: {result.Error.Type} is not implemented")
            };
    }
}
