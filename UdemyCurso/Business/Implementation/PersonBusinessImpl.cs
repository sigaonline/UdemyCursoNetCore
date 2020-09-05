using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Data.Converters;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImpl(IRepository<Person> context)
        {
            _repository = context;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindBy(long id)
        {
            return _converter.Parse(_repository.FindBy(id));

        }

        public PersonVO Update(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

    }
}
