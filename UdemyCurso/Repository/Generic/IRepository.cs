using System.Collections.Generic;
using UdemyCurso.Model.Base;

namespace UdemyCurso.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindBy(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        List<T> FindWithPageSearch(string query);
    }
}
