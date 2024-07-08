using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [Route("WebKrpcApi/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os métodos do controlador
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService clientService)
        {
            _service = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetAll()
        {
            var clients = await _service.GetAll();
            if (clients == null) return NotFound("Nenhum cliente encontrado.");
            return Ok(clients);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<ClientDto>> GetClient(string email)
        {
            var client = await _service.GetByEmail(email);
            if (client == null) return NotFound($"Cliente com email {email} não encontrado.");
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Save([FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var savedClient = await _service.Save(clientDto);
            return CreatedAtAction(nameof(GetClient), new { email = savedClient.Email }, savedClient);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            var client = await _service.GetByEmail(email);
            if (client == null) return NotFound($"Cliente com email {email} não encontrado.");

            await _service.Delete(client);
            return NoContent();
        }
    }
}