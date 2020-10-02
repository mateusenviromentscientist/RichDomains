using System;
using Flunt.Notifications;
using Flunt.Validations;
using RichDomains.Domain.EDocumentTypes;
using RichDomains.Domain.ValueObjetcs;
using RichDomains.Shared.Commands;

namespace RichDomains.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName {get;  set;}
        public string LastName {get; set;}

        public string Number {get;  set;}

        public string Address {get;  set;}

        public string CardHolderName {get; set;}
        public string CardNumber {get; set;}

        public string LastTransictionNumber {get; set;}

        public string PaymentNumber { get;  set; }
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalPaid { get;  set; }
        public string PayerDocument {get; set;}
        public string Payer { get;  set; }
        public EDocumentType PayerDocumentType { get;  set; }
        public Address PaymentAddress { get;  set; }
        public string PayerEmail { get;  set; }
        public string Stret { get;  set; }
        public string NumberAddress { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Contry {get;  set;}
        public string zipCode { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
           .Requires()
           .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter no minimo 3 caracteres")
           .HasMinLen(LastName, 3, "Name.LastName", "Nome deve conter no minimo 3 caracteres")
           .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter no minimo 3 caracteres"));
        }

    }

}
