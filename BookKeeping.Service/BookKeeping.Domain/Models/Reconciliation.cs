using System.ComponentModel.DataAnnotations;

namespace BookKeeping.Service.API.Models
{
    public class Reconciliation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public ReconciliationType Type { get; set; }
    }

    public enum ReconciliationType
    {
        Expense = 5,
        Income = 10
    }
}
