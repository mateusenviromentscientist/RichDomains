using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichDomains.Domain.Commands;
namespace RichDomain.Tests
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}   