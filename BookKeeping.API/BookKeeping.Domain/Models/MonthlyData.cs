using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Domain.Models
{
    public class MonthlyData
    {
        public MonthlyData()
        {

        }
        public int Id { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Year { get; set; }
        public decimal Income { get; set; } = 0;
        public decimal Cost { get; set; } = 0;
    }
}
