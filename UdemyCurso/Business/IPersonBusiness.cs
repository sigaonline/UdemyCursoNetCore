using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindBy(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
