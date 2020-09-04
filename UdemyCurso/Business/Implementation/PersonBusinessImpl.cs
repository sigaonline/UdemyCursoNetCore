using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IRepository<Person> _repository;
        public PersonBusinessImpl(IRepository<Person> context)
        {
            _repository = context;
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindBy(long id)
        {
            return _repository.FindBy(id);

        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
