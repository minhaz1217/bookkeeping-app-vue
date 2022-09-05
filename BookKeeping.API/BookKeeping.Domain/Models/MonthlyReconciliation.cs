using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Domain.Models
{
    public class MonthlyReconciliation
    {
        public int Id { get; set; }
        public int MonthlyDataId { get; set; }
        public int  ReconciliationId { get; set; }
        public decimal Value { get; set; }
        virtual public Reconciliation Reconciliation { get; set; } = null;
        virtual public MonthlyData MonthlyData { get; set; } = null;
    }
}
