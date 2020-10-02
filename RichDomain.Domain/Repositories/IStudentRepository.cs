using RichDomains.Domain.Entities;

namespace RichDomains.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}