using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeping.Service.API.Models
{
    public class MonthlyReconciliation
    {
        public int Id { get; set; }
        public int MonthlyDataId { get; set; }
        public int ReconciliationId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get; set; }

        public MonthlyData MonthlyData { get; set; } = null;
        public Reconciliation Reconciliation { get; set; } = null;

    }
}
