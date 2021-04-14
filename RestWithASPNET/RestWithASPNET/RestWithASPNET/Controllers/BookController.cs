using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Controllers
{
    //[ApiVersion("1")]
    [ApiController]
    [Route("v1/api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookBusiness _bookBusiness;


        public BookController(ILogger<BookController> logger, IBookBusiness bookService)
        {
            _logger = logger;
            _bookBusiness = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _bookBusiness.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        //[FromBody] pega o json que esta no body da requisicao e o converte para um Person
        public IActionResult Create([FromBody] BookVO book)
        {

            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookVO book)
        {

            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}
