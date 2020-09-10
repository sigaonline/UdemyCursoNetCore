using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS.Utils;
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

        private IPersonRepository _repository;

        private readonly PersonConverter _converter;
        public PersonBusinessImpl(IPersonRepository context)
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

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
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

        public PagedSearchDTO<PersonVO> FindWithPageSearch(string name, string sortDirection, int pageSize, int page)
        {
            var query = "select * from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name))
                query += $"and p.FirstName like '%{name}%' ";

            query += $"order by p.FirstName {sortDirection} limit {pageSize} offset {page}";

          //  string countQuery = @"select count(*) from Persons p where 1 = 1 ";
          //  if (!string.IsNullOrEmpty(name))
          //      countQuery = countQuery + $"and p.FirstName like '%{name}%' ";

            var persons = _converter.ParseList(_repository.FindWithPageSearch(query));
            int totalResults = persons.Count(); //_repository.FindWithPageSearch(countQuery).Count();

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }

    }
}
