using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository;

namespace UdemyCurso.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _repository;
        public PersonBusinessImpl(IPersonRepository context)
        {
            _repository = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _repository.Create(person);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {
                _repository.Delete(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
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
