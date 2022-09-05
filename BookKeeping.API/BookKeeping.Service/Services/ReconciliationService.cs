using BookKeeping.Domain.Models;
using BookKeeping.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public class ReconciliationService
    {
        private readonly IMonthlyDataRepository _monthlyDataRepository;
        public ReconciliationService(IMonthlyDataRepository monthlyDataRepository)
        {
            _monthlyDataRepository = monthlyDataRepository;
        }

        public async Task<MonthlyData> GetMonthlyData(int year)
        {
            var monthlyDatas = new List<MonthlyData>();
            //MonthlyData.GetMonthlyDataByYear(year)
            //return await _monthlyDataRepository.GetByIDAsync(id);

            return monthlyDatas.First();
        }
    }
}
