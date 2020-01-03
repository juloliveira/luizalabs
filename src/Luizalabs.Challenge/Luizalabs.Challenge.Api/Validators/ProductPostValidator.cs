using FluentValidation;
using Luizalabs.Challenge.Contracts.v1.Requests;

namespace Luizalabs.Challenge.Api.Validators
{
    public class ProductPostValidator : AbstractValidator<ProductPost>
    {
        public ProductPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("O campo NOME DO PRODUTO precisa ser preenchido.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("O campo PREÇO precisa ser preenchido e ter valor maior que zero.");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("Você precisa selecionar um FABRICANTE para cadastrar um produto.");
        }
    }
}
