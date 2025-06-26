using BiblioCleanSol.Application.Dtos.Libros.Estados;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Application.Services.Libros;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioCleanSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosService _estadosService;

        public EstadosController(IEstadosService estadosService)
        {
            _estadosService = estadosService;
        }


        // GET: api/<EstadosController>
        [HttpGet("Estados")]
        public async Task<IActionResult> Get()
        {
            var result = await _estadosService.ObtenerEstadosAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/<EstadosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstadosController>
        [HttpPost("Save")]
        public async Task<IActionResult> Post([FromBody] EstadosDto estadosDto)
        {
            var result = await _estadosService.GuardarEstadosAsync(estadosDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        // PUT api/<EstadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
