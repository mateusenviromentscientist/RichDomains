
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichDomains.Domain.EDocumentTypes;
using RichDomains.Domain.Entities;
using RichDomains.Domain.Queries;
using RichDomains.Domain.ValueObjetcs;

namespace RichDomain.Tests
{

    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;
        
        public StudentQueriesTests()
        {
            for (var i =0; i<=10; i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()), new Email((i.ToString()+"@beludo.com")),new Document("111111111"+ i.ToString(),EDocumentType.CPF)));
            }
        }

        [TestMethod]
        public void ShoulReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentsInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShoulReturnStudentWhenDocumenttExists()
        {
            var exp = StudentQueries.GetStudentsInfo("111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }

    }
}