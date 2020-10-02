using System;
using System.Linq.Expressions;
using RichDomains.Domain.Entities;

namespace RichDomains.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentsInfo(string document)
        {
            return x => x.Document.Number == document ;
        }
    }
}