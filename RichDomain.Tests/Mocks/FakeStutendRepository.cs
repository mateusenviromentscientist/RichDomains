using RichDomains.Domain.Entities;
using RichDomains.Domain.Repositories;

namespace RichDomain.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if(document == "123456789111")
                 return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "power@guido.com")
                return true;
            return false;

        }
    }
}