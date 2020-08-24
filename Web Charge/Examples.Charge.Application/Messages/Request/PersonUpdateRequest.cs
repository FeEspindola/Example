using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonUpdateRequest
    {
        public int  BusinessEntityID { get; set; }
        public string Name { get; set; }
        public ICollection<PersonPhoneUpdateRequest> Phones { get; set; }
    }
}