using BookKeeping.Domain.Models;
using BookKeeping.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public class MonthlyDataService : IMonthlyDataService
    {
        private readonly IMonthlyDataRepository _monthlyDataRepository;
        public MonthlyDataService(IMonthlyDataRepository monthlyDataRepository)
        {
            _monthlyDataRepository = monthlyDataRepository;
        }

        public async Task<MonthlyData> GetByIDAsync(int id)
        {
            return await _monthlyDataRepository.GetByIDAsync(id);
        }
    }
}
