using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Repository.Repositories
{
    public class MonthlyReconciliationRepository : IMonthlyReconciliationRepository
    {
        private readonly IGenericRepository<MonthlyReconciliation> _repo;

        public MonthlyReconciliationRepository(IGenericRepository<MonthlyReconciliation> repo)
        {
            _repo = repo;
        }

        public async Task<IList<MonthlyReconciliation>> GetReconciliations(
            IList<int>? reconciliationIds = null,
            IList<int>? monthlyDataIds = null)
        {
            Expression<Func<MonthlyReconciliation, bool>> filter = (reconciliation) =>
                (reconciliationIds != null && reconciliationIds.Count > 0 ? reconciliationIds.Contains(reconciliation.ReconciliationId) : true) &&
                (monthlyDataIds != null && monthlyDataIds.Count > 0 ? monthlyDataIds.Contains(reconciliation.MonthlyDataId) : true);
            return (await _repo.GetAsync(filter)).ToList();
        }
    }
}
