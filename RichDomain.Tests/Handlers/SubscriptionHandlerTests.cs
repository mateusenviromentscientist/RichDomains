using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichDomains.Domain.ValueObjetcs;
using RichDomains.Domain.Entities;
using RichDomains.Domain.EDocumentTypes;
using System;
using RichDomains.Domain.Handlers;
using RichDomain.Tests.Mocks;
using RichDomains.Domain.Commands;

namespace RichDomains.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumetExists()
        {
           var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
           var command = new CreateBoletoSubscriptionCommand();
           command.FirstName = "Power";
           command.LastName = "Guido";
           command.PayerDocument= "999999999";

           command.PayerEmail = "power@guido1.com";
           command.BarCode = "1234567896";
           command.BoletoNumber= "1234567898";
           command.PaymentNumber="123466";
           command.PaidDate = DateTime.Now;
           command.ExpireDate = DateTime.Now.AddMonths(1);
           command.Total = 60;
           command.TotalPaid = 60;
           command.Payer = "Power Guido S&A";
           command.PayerDocument = "1234568798743";
           command.PayerDocumentType = EDocumentType.CPF;
           command.Stret = "Paula Tejando";
           command.Number = "asasd";
           command.City = "Rick";
           command.Neighborhood = "Barroso";
           command.State = "Tomas Turbando";
           command.Country = "Brazil";
           command.zipCode="124654984354";
           
           handler.Handle(command);
           Assert.AreEqual(false, handler.Valid);



           
        }
    }
}  