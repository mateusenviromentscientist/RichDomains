using Flunt.Validations;
using RichDomains.Shared.ValueObjects;

namespace RichDomains.Domain.ValueObjetcs 
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
           Address = address;

           AddNotifications(new Contract()
               .Requires().IsEmail(Address, "Email.Address", "E-mail inválido")
           );
        }
    
        public string Address {get; private set;}
    
    }
}