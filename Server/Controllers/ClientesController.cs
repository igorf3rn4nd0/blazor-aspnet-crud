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
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var clienteDto = await _clienteService.GetClienteByIdAsync(id);
            if (clienteDto == null)
            {
                _logger.LogWarning($"Cliente with id {id} not found.");
                return NotFound();
            }
            return Ok(clienteDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> PostCliente([FromBody] ClienteDto clienteDto)
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
