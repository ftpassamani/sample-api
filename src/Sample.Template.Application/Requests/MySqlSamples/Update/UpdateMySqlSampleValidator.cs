using FluentValidation;

namespace Sample.Template.Application.Requests.MySqlSamples.Update
{
    public class UpdateMySqlSampleValidator : AbstractValidator<UpdateMySqlSampleRequest>
    {
        public UpdateMySqlSampleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
