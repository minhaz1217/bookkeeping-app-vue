using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task<IList<MonthlyReconciliation>> GetMonthlyReconciliations(IList<int>? monthlyDataIds = null)
        {

            string query = @"
                SELECT 
                    * 
                FROM MonthlyReconciliation
                ";
            var parameters = new List<SqlParameter>();
            StringBuilder whereClause = new StringBuilder();
            if (monthlyDataIds != null && monthlyDataIds.Count > 0)
            {
                whereClause.Append(string.Format("MonthlyDataId IN {0}", "(" + string.Join(",", monthlyDataIds) + ")"));
            }

            if(whereClause.Length > 0)
            {
                query = query + " WHERE " + whereClause.ToString();
            }

            query += ";";

            return await _repo.RawAsync(query);
            
            //Expression<Func<MonthlyReconciliation, bool>> filter = (reconciliation) =>
            //    (reconciliationIds != null && reconciliationIds.Count > 0 ? reconciliationIds.Any( r => r == reconciliation.ReconciliationId) : true) &&
            //    (monthlyDataIds != null && monthlyDataIds.Count > 0 ? monthlyDataIds.Any(r => r == reconciliation.MonthlyDataId) : true);
            //return (await _repo.GetAsync(filter)).ToList();
        }


        public bool UpdateMonthlyReconciliations(IList<MonthlyReconciliation> reconciliations)
        {
            if(reconciliations == null || reconciliations.Count == 0)
            {
                return false;
            }

            foreach(var reconciliation in reconciliations)
            {
                _repo.Update(reconciliation);
            }
            return true;
        }

    }
}
