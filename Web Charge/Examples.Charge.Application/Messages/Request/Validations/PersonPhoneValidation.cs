using Examples.Charge.Domain.Aggregates.PersonAggregate;
using FluentValidation;

namespace Examples.Charge.Application.Messages.Request.Validations
{
    public class PersonPhoneValidation : AbstractValidator<PersonPhoneRequest>
    {
        public PersonPhoneValidation()
        {
            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.PhoneNumberTypeID)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

        }
        
    }
}