using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindBy(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long? id);
    }
}
