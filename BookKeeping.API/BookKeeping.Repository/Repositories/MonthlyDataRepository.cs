using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Repository.Repositories
{
    public class MonthlyDataRepository : IMonthlyDataRepository
    {
        private readonly IGenericRepository<MonthlyData> _repo;

        public MonthlyDataRepository(IGenericRepository<MonthlyData> repo)
        {
            _repo = repo;
        }

        public async Task<MonthlyData> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }
    }
}
