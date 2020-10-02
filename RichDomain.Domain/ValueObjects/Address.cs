using Flunt.Validations;
using RichDomains.Shared.ValueObjects;

namespace RichDomains.Domain.ValueObjetcs
{
    public class Address : ValueObject
    {
        public Address(string stret, string number, string neighborhood, string city, string state, string contry, string zipCode)
        {
            Stret = stret;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Contry = contry;
            this.zipCode = zipCode;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Stret,3,"Address.Street", "Nome deve conter pelo menos 3 caracteres"));
        }

        public string Stret { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Contry {get; private set;}
        public string zipCode { get; private set; }


        
    }
}