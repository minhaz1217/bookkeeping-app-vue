using BookKeeping.Domain.Models;
using BookKeeping.Repository.Repositories;
using BookKeeping.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public class ReconciliationService : IReconciliationService
    {
        #region CTOR
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

        #endregion CTOR


        public async Task<YearModel> GetReconciliations(int year)
        {
            //var monthlyDatas = new List<MonthlyData>();
            var monthlyDatas = await _monthlyDataService.GetMonthlyDatas(year);
            var monthlyDatasIds = monthlyDatas.Select(x => x.Id).ToList();

            var monthlyReconciliations = await _monthlyReconciliationRepository.GetMonthlyReconciliations(monthlyDatasIds);

            var distinctReconciliationIds = monthlyReconciliations.Select(x => x.ReconciliationId).Distinct();

            var reconciliations = await _reconciliationRepository.GetReconciliationsByIds(distinctReconciliationIds.ToList());

            return PrepareYearModel(year, monthlyDatas, monthlyReconciliations, reconciliations);
        }

        private YearModel PrepareYearModel(int year, IList<MonthlyData> months, IList<MonthlyReconciliation> monthlyReconciliations, IList<Reconciliation> reconciliations)
        {
            var yearModel = new YearModel();
            yearModel.Year = year;

            months = months.OrderBy(x => x.Month).ToList();
            foreach (var month in months)
            {
                yearModel.MonthlyDatas.Add(PrepareMonthModel(month, monthlyReconciliations, reconciliations));
            }
            return yearModel;
        }

        private MonthModel PrepareMonthModel(MonthlyData month, IList<MonthlyReconciliation> monthlyReconciliations, IList<Reconciliation> reconciliations)
        {
            var monthModel = new MonthModel();
            monthModel.Month = month.Month;
            monthModel.Income = month.Income;
            monthModel.Cost = month.Cost;

            var incomes = new List<ReconciliationModel>();
            var expenses = new List<ReconciliationModel>();

            monthlyReconciliations = monthlyReconciliations.Where(x => x.MonthlyDataId == month.Id).ToList();
            foreach (var monthlyReconciliation in monthlyReconciliations)
            {
                var reconciliation = reconciliations.Where(x => x.Id == monthlyReconciliation.ReconciliationId).FirstOrDefault();
                if (reconciliation != null)
                {
                    var data = new ReconciliationModel
                    {
                        Id = monthlyReconciliation.Id,
                        ReconciliationId = reconciliation.Id,
                        Name = reconciliation.Name,
                        Value = monthlyReconciliation.Value,
                        Type = reconciliation.Type,
                    };

                    if (reconciliation.Type == ReconciliationType.Income)
                    {
                        incomes.Add(data);
                    }
                    else
                    {
                        expenses.Add(data);
                    }
                }
            }
            incomes.OrderBy(x => x.Name);
            expenses.OrderBy(x => x.Name);

            monthModel.Incomes = incomes;
            monthModel.Expenses = expenses;

            return monthModel;
        }

        public async Task<bool> SaveReconciliationDataAsync(YearModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (model.MonthlyDatas.Count == 0)
            {
                return false;
            }

            var monthlyDatas = await _monthlyDataService.GetMonthlyDatas(model.Year);
            var monthlyDatasIds = monthlyDatas.Select(x => x.Id).ToList();

            var monthlyReconciliations = await _monthlyReconciliationRepository.GetMonthlyReconciliations(monthlyDatasIds);
            var currentReconciliationModels = new List<ReconciliationModel>();
            currentReconciliationModels.AddRange(model.MonthlyDatas.SelectMany(x => x.Incomes));
            currentReconciliationModels.AddRange(model.MonthlyDatas.SelectMany(x => x.Expenses));


            var reconciliationsNeededToBeUpdated = new List<MonthlyReconciliation>();
            foreach (var currentReconciliation in currentReconciliationModels)
            {
                var reconciliation = monthlyReconciliations.Where(x => x.Id == currentReconciliation.Id).FirstOrDefault();
                if (reconciliation != null)
                {
                    if (reconciliation.Value != currentReconciliation.Value)
                    {
                        reconciliation.Value = currentReconciliation.Value;
                        reconciliationsNeededToBeUpdated.Add(reconciliation);
                    }
                }
            }

            return _monthlyReconciliationRepository.UpdateMonthlyReconciliations(reconciliationsNeededToBeUpdated);
        }


    }
}
