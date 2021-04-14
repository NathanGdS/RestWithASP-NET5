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
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusiness _personBusiness;


        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personBusiness = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        //[FromBody] pega o json que esta no body da requisicao e o converte para um Person
        public IActionResult Create([FromBody] PersonVO person)
        {
           
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonVO person)
        {

            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }
}
