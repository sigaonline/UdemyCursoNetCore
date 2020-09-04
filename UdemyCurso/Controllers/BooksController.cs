using Microsoft.AspNetCore.Mvc;
using UdemyCurso.Model;

namespace UdemyCurso.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class BooksController : Controller
    {

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_bookBusiness.FindAll());
            return Ok();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var person = _bookBusiness.FindBy(id);
            //if (person == null) return NotFound();

            //return Ok(person);
            return Ok();
        }

        // GET api/values/5
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            //if (person == null) return BadRequest();

            //return new ObjectResult(_bookBusiness.Create(person));
            return Ok();
        }

        // GET api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            //if (person == null) return BadRequest();
            //var updatePerson = _bookBusiness.Update(person);
            //if (updatePerson == null) return BadRequest();

            //return new ObjectResult(updatePerson);
            return Ok();
        }

        // GET api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //_bookBusiness.Delete(id);
            //return NoContent();
            return Ok();
        }


    }
}
