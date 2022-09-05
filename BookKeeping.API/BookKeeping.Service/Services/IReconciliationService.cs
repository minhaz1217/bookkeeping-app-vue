using BookKeeping.Domain.Models;
using BookKeeping.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Services
{
    public interface IReconciliationService
    {
        Task<YearModel> GetReconciliations(int year);
        Task<bool> SaveReconciliationDataAsync(YearModel model);
    }
}
