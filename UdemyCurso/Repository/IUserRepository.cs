using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Repository
{
    public interface IUserRepository
    {
    
        User FindByLogin(string login);
     
    }
}
