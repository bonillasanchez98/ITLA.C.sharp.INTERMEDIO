using BiblioCleanSol.Application.Dtos.Usuarios;
using BiblioCleanSol.Application.Interfaces.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioCleanSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // GET: api/<UsuarioController>
        [HttpGet("Usuarios")]
        public async Task<IActionResult> Get()
        {
            var result = await _usuarioService.ObtenerUsuariosAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost("Save")]
        public async Task<IActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            var result = _usuarioService.GuardarUsuarioAsync(usuarioDto);
            if (!result.IsCompleted)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
