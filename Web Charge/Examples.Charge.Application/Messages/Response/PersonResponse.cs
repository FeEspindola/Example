using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public PersonResponse()
        {
            PersonObjects = new List<PersonDto>();
        }
        public List<PersonDto> PersonObjects { get; set; }
    }
}
