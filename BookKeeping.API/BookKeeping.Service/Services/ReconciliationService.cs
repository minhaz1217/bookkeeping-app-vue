using BookKeeping.Domain.Models;
using BookKeeping.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public class ReconciliationService : IReconciliationService
    {
        private readonly IMonthlyDataService _monthlyDataService;
        private readonly IMonthlyReconciliationRepository _monthlyReconciliationRepository;
        private readonly IReconciliationRepository _reconciliationRepository;

        public ReconciliationService(
            IMonthlyDataService monthlyDataService,
            IReconciliationRepository reconciliationRepository,
            IMonthlyReconciliationRepository monthlyReconciliationRepository
        )
        {
            _monthlyDataService = monthlyDataService;
            _reconciliationRepository = reconciliationRepository;
            _monthlyReconciliationRepository = monthlyReconciliationRepository;
        }

        public async Task<IList<MonthlyData>> GetReconciliations(int year)
        {
            //var monthlyDatas = new List<MonthlyData>();
            var monthlyDatas = await _monthlyDataService.GetMonthlyDatas(year);
            var monthlyDatasIds = monthlyDatas.Select(x => x.Id).ToList();

            var monthlyReconciliations = await _monthlyReconciliationRepository.GetReconciliations(monthlyDatasIds);

            return monthlyDatas;
        }
    }
}
