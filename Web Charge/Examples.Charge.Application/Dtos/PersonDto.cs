using System.Collections.Generic;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDto
    {

        public string Name { get; set; }
        public IEnumerable<PersonPhoneDto> Phones { get; set; }
    }
}
