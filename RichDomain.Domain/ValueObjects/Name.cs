using Flunt.Validations;
using RichDomains.Shared.ValueObjects;

namespace RichDomains.Domain.ValueObjetcs 
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

           
           AddNotifications(new Contract().Requires().HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter no minimo 3 caracteres"));
           AddNotifications(new Contract().Requires().HasMinLen(LastName, 3, "Name.LastName", "Nome deve conter no minimo 3 caracteres"));
           AddNotifications(new Contract().Requires().HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter no minimo 3 caracteres"));
        }
    
        public string FirstName {get; private set;}
        public string LastName {get;private set;}

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    
    }
}