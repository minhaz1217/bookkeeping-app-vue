using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeping.Service.API.Models
{
    public class MonthlyData
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Income { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cost { get; set; }
        public int Month { get; set; }
        public string Year { get; set; } = String.Empty;
        public ICollection<MonthlyReconciliation> MonthlyReconciliations { get; set; } = new List<MonthlyReconciliation>();
    }

}
