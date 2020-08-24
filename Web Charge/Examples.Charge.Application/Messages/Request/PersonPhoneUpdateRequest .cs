namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneUpdateRequest 
    {
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }
    }
}