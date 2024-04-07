using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [Route("WebKrpcApi/[controller]")]
    // WebKrpcApi/budget
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService budgetService)
        {
            _service = budgetService;
        }

        [HttpGet]
        public List<BudgetDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public BudgetDto GetClient(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public BudgetDto Save(BudgetDto budgetDto)
        {
            return _service.Save(budgetDto).Result;
        }

        [HttpDelete]
        public void Delete(BudgetDto budgetDto)
        {
            _service.Delete(budgetDto);
        }
    }
}