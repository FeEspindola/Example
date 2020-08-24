using Abp.Events.Bus;
using System;
using System.Collections.Generic;


namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class Person
    {
        public int BusinessEntityID { get; set; }

        public string Name { get; set; }

        private readonly List<PersonPhone> _phones;
        public  IReadOnlyCollection<PersonPhone> Phones => _phones;

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

      

        public Person(string name)
        {
            Name = name;
            _phones = new List<PersonPhone>();
        }

        public Person(int businessEntityID, string name)
        {
            _phones = new List<PersonPhone>();
            BusinessEntityID = businessEntityID;
            Name = name;
        }

        //construtor para EF
        protected Person()
        {
            _phones = new List<PersonPhone>();
        }
   

        public void AddPhone(string phoneNumber, int phoneNumberTypeID)
        {
            _phones.Add(new PersonPhone(phoneNumber, phoneNumberTypeID));
        }

        public void UpdatePhone(int businessEntityID ,string phoneNumber, int phoneNumberTypeID)
        {
            _phones.Add(new PersonPhone(businessEntityID,phoneNumber, phoneNumberTypeID));
        }
    }
}
