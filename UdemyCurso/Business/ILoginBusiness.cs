using System.Collections.Generic;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User login);
     
    }
}
