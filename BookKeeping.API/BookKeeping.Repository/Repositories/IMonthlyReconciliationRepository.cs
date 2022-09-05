using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Repository.Repositories
{
    public interface IMonthlyReconciliationRepository
    {
        Task<IList<MonthlyReconciliation>> GetReconciliations(
            IList<int>? reconciliationIds = null,
            IList<int>? monthlyDataIds = null);
    }
}
