using Microsoft.AspNetCore.Mvc;
using UdemyCurso.Business;
using UdemyCurso.Model;

namespace UdemyCurso.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class BooksController : Controller
    {
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.FindBy(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        // GET api/values/5
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
   
        }

        // GET api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null) return BadRequest();

            return new ObjectResult(updateBook);

        }

        // GET api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
           
        }


    }
}
