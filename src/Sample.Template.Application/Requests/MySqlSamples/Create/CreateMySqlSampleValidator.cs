using FluentValidation;

namespace Sample.Template.Application.Requests.MySqlSamples.Create
{
    public class CreateMySqlSampleValidator : AbstractValidator<CreateMySqlSampleRequest>
    {
        public CreateMySqlSampleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
