using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Service.Models
{
    public class YearModel
    {
        public int Year { get; set; }
        public IList<MonthModel> MonthlyDatas { get; set; } = new List<MonthModel>();

    }

    public class MonthModel
    {
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Cost { get; set; }
        public IList<ReconciliationModel> Incomes { get; set; } = new List<ReconciliationModel>();
        public IList<ReconciliationModel> Expenses { get; set; } = new List<ReconciliationModel>();
    }

    public class ReconciliationModel
    {
        public int Id { get; set; }
        public int ReconciliationId { get; set; }
        public string Name{ get; set; }
        public ReconciliationType Type { get; set; }
        public decimal Value { get; set; }
    }
}
