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
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService budgetService)
        {
            _service = budgetService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BudgetDto>>> GetAll()
        {
            var budgets = await _service.GetAll();
            return Ok(budgets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> GetById(int id)
        {
            var budget = await _service.GetById(id);
            if (budget == null) return NotFound("Orçamento não encontrado.");
            return Ok(budget);
        }

        [HttpPost]
        public async Task<ActionResult<BudgetDto>> Save([FromBody] BudgetDto budgetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var savedBudget = await _service.Save(budgetDto);
            return CreatedAtAction(nameof(GetById), new { id = savedBudget.Id }, savedBudget);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var budget = await _service.GetById(id);
            if (budget == null) return NotFound("Orçamento não encontrado.");

            await _service.Delete(budget);
            return NoContent();
        }
    }
}