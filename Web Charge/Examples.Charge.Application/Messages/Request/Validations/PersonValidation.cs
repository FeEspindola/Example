using FluentValidation;

namespace Examples.Charge.Application.Messages.Request.Validations
{
    public class PersonValidation : AbstractValidator<PersonRequest>
    {
        public PersonValidation()
        {

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.Phones)
                .NotEmpty()
                .WithMessage("O e-mail informado não é válido.");

  
        }
    }
}