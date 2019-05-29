using System.Collections.Generic;
using AulaLTP6.Domain.Entities;
using AulaLTP6.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AulaLTP6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personRepository.List();
        }
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _personRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            _personRepository.Create(person);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person person)
        {
            _personRepository.Update(person);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }
    }
}