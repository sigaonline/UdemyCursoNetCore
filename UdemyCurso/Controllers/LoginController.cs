using Microsoft.AspNetCore.Mvc;
using UdemyCurso.Model;
using UdemyCurso.Business;
using Microsoft.AspNetCore.Authorization;
using Tapioca.HATEOAS;

namespace UdemyCurso.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness personBusiness)
        {
            _loginBusiness = personBusiness;
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public object Post([FromBody] User user)
        {
            if (user == null) return BadRequest();

            return _loginBusiness.FindByLogin(user);
        }

    
    }
}
