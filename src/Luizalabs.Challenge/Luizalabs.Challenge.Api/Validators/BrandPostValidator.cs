using FluentValidation;
using Luizalabs.Challenge.Contracts.v1.Requests;

namespace Luizalabs.Challenge.Api.Validators
{
    public class BrandPostValidator : AbstractValidator<BrandPost>
    {
        public BrandPostValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo NOME precisa ser preenchido.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("O campo NOME precisa ter pelo menos 3 caracteres.");
        }
    }
}
