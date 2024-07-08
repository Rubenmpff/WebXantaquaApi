using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Infra.Data.Repositories.Interfaces;
using WebXantaquaApi.Services.Mapping.Dtos;
using WebXantaquaApi.Services.Services.Interfaces;

namespace WebXantaquaApi.Services.Services.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _repository;

        public BudgetService(IMapper mapper, IBudgetRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<BudgetDto>> GetAll()
        {
            var budgets = await _repository.GetAll();
            return _mapper.Map<List<BudgetDto>>(budgets);
        }

        public async Task<BudgetDto> GetById(int id)
        {
            var budget = await _repository.GetById(id);
            if (budget == null)
            {
                throw new KeyNotFoundException("Budget not found.");
            }
            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task<BudgetDto> Save(BudgetDto budgetDto)
        {
            var budget = _mapper.Map<Budget>(budgetDto);
            if (budget.Id > 0)
            {
                await _repository.UpdateAsync(budget);
            }
            else
            {
                await _repository.AddAsync(budget);
            }
            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task Delete(BudgetDto budgetDto)
        {
            var budget = _mapper.Map<Budget>(budgetDto);
            await _repository.DeleteAsync(budget);
        }
    }
}
