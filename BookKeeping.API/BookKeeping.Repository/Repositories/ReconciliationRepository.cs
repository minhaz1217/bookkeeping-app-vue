using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
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

        public async Task<IList<Reconciliation>> GetReconciliationsByNames(IList<string> names)
        {
            Expression<Func<Reconciliation, bool>> filter = (reconciliation) => (names.Contains(reconciliation.Name));
            return (await _repo.GetAsync(filter)).ToList();
        }
    }
}
