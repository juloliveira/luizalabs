using FluentValidation;
using Luizalabs.Challenge.Contracts.v1.Requests;

namespace Luizalabs.Challenge.Api.Validators
{
    public class ReviewPutValidator : AbstractValidator<ReviewPut>
    {
        public ReviewPutValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CLIENTE inválido.");
            RuleFor(x => x.Score)
                .GreaterThan(0).WithMessage("Sua AVALIAÇÃO deve ter uma nota de 1 a 5.")
                .LessThanOrEqualTo(5).WithMessage("Sua AVALIAÇÃO deve ter uma nota de 1 a 5.");
        }
    }
}
