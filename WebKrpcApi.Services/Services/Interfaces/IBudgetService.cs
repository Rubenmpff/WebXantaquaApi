using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<List<BudgetDto>> GetAll();

        Task<BudgetDto> GetById(int id);

        Task<BudgetDto> Save(BudgetDto budgetDto);

        Task Delete(BudgetDto budgetDto);
    }
}
