using System.Collections.Generic;
using Examples.Charge.Application.Messages.Request.Validations;
using FluentValidation.Results;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public ICollection<PersonPhoneRequest> Phones { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new PersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
