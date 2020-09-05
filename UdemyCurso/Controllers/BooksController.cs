using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UdemyCurso.Business;
using UdemyCurso.Data.VO;
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
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }
        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.FindBy(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        // GET api/values/5
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(List<BookVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
   
        }

        // GET api/values/5
        [HttpPut]
        [ProducesResponseType((201), Type = typeof(List<BookVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null) return BadRequest();

            return new ObjectResult(updateBook);

        }

        // GET api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
           
        }


    }
}
