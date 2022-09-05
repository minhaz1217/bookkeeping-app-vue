using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Domain.Models
{
    public class Reconciliation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  = string.Empty;
        public ReconciliationType Type { get; set; }
    }

    public enum ReconciliationType
    {
        Expense = 5,
        Income = 10
    }
}
