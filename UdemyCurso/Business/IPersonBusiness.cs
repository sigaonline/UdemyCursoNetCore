using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindBy(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchDTO<PersonVO> FindWithPageSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
