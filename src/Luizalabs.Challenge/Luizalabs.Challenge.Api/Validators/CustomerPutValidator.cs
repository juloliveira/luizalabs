using FluentValidation;
using Luizalabs.Challenge.Contracts.v1.Requests;

namespace Luizalabs.Challenge.Api.Validators
{
    public class CustomerPutValidator : AbstractValidator<CustomerPut>
    {
        public CustomerPutValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo NOME precisa ser preenchido");
            RuleFor(x => x.Address).NotEmpty().WithMessage("O campo ENDEREÇO precisa ser preenchido");
        }
    }
}
