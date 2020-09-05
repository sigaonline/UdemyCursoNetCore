using System.Collections.Generic;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindBy(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
