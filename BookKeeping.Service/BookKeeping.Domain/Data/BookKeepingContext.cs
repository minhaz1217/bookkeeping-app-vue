using BookKeeping.Service.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Domain.Data
{
    internal class BookKeepingContext : DbContext
    {
        public DbSet<Reconciliation> Reconciliations { get; set; } = null;
        public DbSet<MonthlyData> MonthlyDatas { get; set; } = null;
        public DbSet<MonthlyReconciliation> MonthlyReconciliations { get; set; } = null;

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
