using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindBy(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}
