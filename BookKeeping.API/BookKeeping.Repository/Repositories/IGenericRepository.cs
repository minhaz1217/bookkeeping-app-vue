using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
        );

        Task<IList<TEntity>> RawAsync(string sql, params object[] parameters);

        Task<TEntity> GetByIDAsync(object id);
        
        TEntity Insert(TEntity entity);
        
        void Delete(object id);
        
        void Delete(TEntity entityToDelete);
        
        TEntity Update(TEntity entityToUpdate);
    }
}
