using AulaLTP6.Domain.Entities;
using System.Collections.Generic;

namespace AulaLTP6.Domain.Repositories
{
    public interface IPersonRepository
    {
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);
        Person GetById(int id);
        IEnumerable<Person> List();
    }
}
