using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedModels;

namespace Server.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clienteDtos = await _clienteService.GetAllClientesAsync();
            return Ok(clienteDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            try
            {
                var clienteDto = await _clienteService.GetClienteByIdAsync(id);
                if (clienteDto == null)
                {
                    return NotFound(new { Message = $"Cliente com ID {id} não encontrado." });
                }

                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro inesperado ao buscar cliente.", Detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ContatoDto>> PostCliente(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.AddClienteAsync(clienteDto);
            return CreatedAtAction(nameof(GetCliente), new { id = clienteDto.Id }, clienteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.UpdateClienteAsync(clienteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}