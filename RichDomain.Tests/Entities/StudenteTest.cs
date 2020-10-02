using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichDomains.Domain.ValueObjetcs;
using RichDomains.Domain.Entities;
using RichDomains.Domain.EDocumentTypes;
using System;

namespace RichDomains.Tests
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Email _email;
        public StudentTest()
        {
           _name = new Name ("Bruce", "Wayne");
           _document = new Document("351111507795", EDocumentType.CPF);
           _email = new Email ("batman@dc.com");
           _address = new Address("Rua 1", "1234", "Bairro Cuca", "Gothan", "SP", "BR","134000");
           _student = new Student(_name, _email, _document);
           _subscription = new Subscription(null);
           
        }

        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var payment = new PayPalPayment("23265","12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, null, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        
        
        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionWitnNoPauyment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("23265","12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, null, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }

    }
}