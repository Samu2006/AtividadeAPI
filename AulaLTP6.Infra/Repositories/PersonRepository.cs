using AulaLTP6.Domain.Entities;
using AulaLTP6.Domain.Repositories;
using AulaLTP6.Infra.Infra;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace AulaLTP6.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDB _DB;

        public PersonRepository(IDB DB)
        {
            _DB = DB;
        }

        public void Create(Person person)
        {
            using (var db = _DB.GetCon())
            {
                var sql = "INSERT INTO [Person] " +
                    " ([Name] " +
                    " ,[CPF] " +
                    " ,[Phone]) " +
                    " VALUES " +
                    " (@Name " +
                    " ,@CPF " +
                    " ,@Phone) ";
                db.Execute(sql, new
                {
                    person.Name,
                    person.CPF,
                    person.Phone
                });
            }
        }

        public void Delete(int id)
        {
            using (var db = _DB.GetCon())
            {
                var sql = "DELETE FROM [Person] WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public Person GetById(int id)
        {
            using (var db = _DB.GetCon())
            {
                var sql = "SELECT * FROM [Person] WHERE Id = @Id";
                return db.Query<Person>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Person> List()
        {
            using (var db = _DB.GetCon())
            {
                var sql = "SELECT * FROM [Person]";
                return db.Query<Person>(sql);
            }
        }

        public void Update(Person person)
        {
            using (var db = _DB.GetCon())
            {
                var sql = "UPDATE [Person] SET" +
                    "[Name] = @Name " +
                    ",[Phone] = @Phone " +
                    "WHERE Id = @Id";
                db.Execute(sql, new
                {
                    person.Id,
                    person.Name,
                    person.CPF,
                    person.Phone
                });
            }
        }
    }
}
