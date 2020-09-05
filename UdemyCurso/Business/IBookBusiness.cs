using System.Collections.Generic;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindBy(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
