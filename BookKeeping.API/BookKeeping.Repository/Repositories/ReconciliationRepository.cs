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
    public class ReconciliationRepository : IReconciliationRepository
    {
        private readonly IGenericRepository<Reconciliation> _repo;

        public ReconciliationRepository(IGenericRepository<Reconciliation> repo)
        {
            _repo = repo;
        }

        public async Task<IList<Reconciliation>> GetReconciliationsByIds(IList<int>? ids = null)
        {
            string query = @"
                SELECT 
                    * 
                FROM Reconciliation
                ";
            var parameters = new List<SqlParameter>();
            StringBuilder whereClause = new StringBuilder();
            if (ids != null && ids.Count > 0)
            {
                whereClause.Append(string.Format("Id IN {0}", "(" + string.Join(",", ids) + ")"));
            }

            if (whereClause.Length > 0)
            {
                query = query + " WHERE " + whereClause.ToString();
            }

            query += ";";

            return await _repo.RawAsync(query);
        }


    }
}
