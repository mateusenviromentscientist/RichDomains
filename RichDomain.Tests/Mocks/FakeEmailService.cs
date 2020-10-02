using RichDomains.Domain.Entities;
using RichDomains.Domain.Repositories;
using RichDomains.Domain.Services;

namespace RichDomain.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}