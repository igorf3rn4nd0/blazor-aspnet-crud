using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedModels;

namespace Server.Controllers
{
    [Route("api")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        
        [HttpGet("clientes/{clienteId}/contatos")]
        public async Task<ActionResult<IEnumerable<ContatoDto>>> GetContatosByCliente(int clienteId)
        {
            var contatoDtos = await _contatoService.GetContatosByClienteIdAsync(clienteId);
            if (contatoDtos == null || !contatoDtos.Any())
            {
                return NoContent();
            }

            return Ok(contatoDtos);
        }
        
        [HttpGet("contatos/{id}")]
        public async Task<ActionResult<ContatoDto>> GetContato(int id)
        {
            var contatoDto = await _contatoService.GetContatoByIdAsync(id);
            if (contatoDto == null)
            {
                return NotFound();
            }
            return Ok(contatoDto);
        }

        [HttpPost("clientes/{clienteId}/contatos")]
        public async Task<ActionResult<ContatoDto>> PostContato(int clienteId, ContatoDto contatoDto)
        {
            contatoDto.IdCliente = clienteId;
            await _contatoService.AddContatoAsync(contatoDto);
            return CreatedAtAction(nameof(GetContato), new { id = contatoDto.Id }, contatoDto);
        }

        [HttpPut("contatos/{id}")]
        public async Task<IActionResult> PutContato(int id, ContatoDto contatoDto)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _contatoService.UpdateContatoAsync(contatoDto);
            return NoContent();
        }
        
        [HttpDelete("contatos/{id}")]
        public async Task<IActionResult> DeleteContato(int id)
        {
            await _contatoService.DeleteContatoAsync(id);
            return NoContent();
        }
    }
}