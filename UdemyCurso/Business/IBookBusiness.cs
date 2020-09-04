using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindBy(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
