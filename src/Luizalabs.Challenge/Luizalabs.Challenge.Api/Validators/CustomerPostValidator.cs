using FluentValidation;
using Luizalabs.Challenge.Contracts.v1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Api.Validators
{

    public class CustomerPostValidator : AbstractValidator<CustomerPost>
    {
        public CustomerPostValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo NOME precisa ser preenchido");
            RuleFor(x => x.Address).NotEmpty().WithMessage("O campo ENDEREÇO precisa ser preenchido");
            RuleFor(x => x.Email).EmailAddress().WithMessage("O campo NOME precisa ser preenchido");
        }
    }
}
