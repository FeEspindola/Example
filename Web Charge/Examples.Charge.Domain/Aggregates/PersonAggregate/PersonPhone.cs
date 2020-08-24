using Abp.Events.Bus;
using System;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone
    {
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public virtual Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

        public PersonPhone(string phoneNumber,int phoneNumberTypeId)
        {
            PhoneNumber = phoneNumber;
            PhoneNumberTypeID = phoneNumberTypeId;
        }

        //construtor para EF
        protected PersonPhone() {
        }


        public PersonPhone(int businessEntityId, string phoneNumber, int phoneNumberTypeId)
        {
            BusinessEntityID = businessEntityId;
            PhoneNumber = phoneNumber;
            PhoneNumberTypeID = phoneNumberTypeId;
        }
    }
}
