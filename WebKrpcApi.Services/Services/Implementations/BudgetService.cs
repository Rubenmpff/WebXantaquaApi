
using AutoMapper;
using Krpc.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Services.Services.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _repository;
        private readonly WebKrpcApiDBContext _context;

        public BudgetService(IMapper mapper, IBudgetRepository repository, WebKrpcApiDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<BudgetDto>> GetAll()
        {
            List<Budget> budgets = await _repository.GetAll();
            return _mapper.Map<List<BudgetDto>>(budgets);
        }

        public async Task<BudgetDto> GetById(int id)
        {

            Budget budget = await _repository.GetById(id);
            return _mapper.Map<BudgetDto>(budget);

        }

        public async Task<BudgetDto> Save(BudgetDto budgetDto)
        {
            Budget budget = _mapper.Map<Budget>(budgetDto);

            if (budgetDto.Id > 0)
            {
                _repository.Update(budget);
            }
            else
            {
                _repository.Add(budget);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task Delete(BudgetDto budgetDto)
        {
            Budget budget = _mapper.Map<Budget>(budgetDto);

            _repository.Delete(budget);

            await _context.SaveChangesAsync();
        }
    }
}
