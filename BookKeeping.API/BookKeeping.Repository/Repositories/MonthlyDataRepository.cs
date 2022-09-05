using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookKeeping.Repository.Repositories
{
    public class MonthlyDataRepository : IMonthlyDataRepository
    {
        private readonly IGenericRepository<MonthlyData> _repo;

        public MonthlyDataRepository(IGenericRepository<MonthlyData> repo)
        {
            _repo = repo;
        }

        public async Task<IList<MonthlyData>> GetMonthlyDatas(int year, int? month)
        {
            //var filter2 = new List<MonthlyData>().AsQueryable().Where(x => x.Year == year);

            Expression<Func<MonthlyData, int>> propertyGetter = product => product.Year;
            Expression<Func<MonthlyData, bool>> filter = (monthlyData) => (monthlyData.Year == year) && ( month.HasValue? monthlyData.Month == month : true) ;

            //Expression<Func<MonthlyData, bool>> filter2 = (monthlyData) =>  (monthlyData.Month == 5);

            

            return (await _repo.GetAsync(filter)).ToList();
        }
    }
}
