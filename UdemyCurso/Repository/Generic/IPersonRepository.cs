using System.Collections.Generic;
using UdemyCurso.Model;
using UdemyCurso.Model.Base;

namespace UdemyCurso.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
      
        List<Person> FindByName(string firstName, string lastName);

    }
}
