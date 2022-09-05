using BookKeeping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Domain.Data
{
    public class BookKeepingContext : DbContext
    {

        public DbSet<Reconciliation> reconciliations { get; set; }
        public DbSet<MonthlyData> monthlyDatas { get; set; }
        public DbSet<MonthlyReconciliation> monthlyReconciliations {get;set;}


        public BookKeepingContext() : base("Data Source=\"localhost, 1433\";Initial Catalog=master;User ID=sa;Password=Asd123!!")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
