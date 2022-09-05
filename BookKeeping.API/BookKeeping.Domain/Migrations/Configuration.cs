namespace BookKeeping.Domain.Migrations
{
    using BookKeeping.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookKeeping.Domain.Data.BookKeepingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookKeeping.Domain.Data.BookKeepingContext context)
        {
            var monthlyDatas = new List<MonthlyData>();
            var reconciliations = new List<Reconciliation>();
            var monthlyReconciliations = new List<MonthlyReconciliation>();
            for (int i = 2020; i <= 2022; i++)
            {
                monthlyDatas.AddRange(GetMonthlyDatasForAYear(i));
            }


            reconciliations.AddRange(GetReconciliations(ReconciliationType.Expense));
            reconciliations.AddRange(GetReconciliations(ReconciliationType.Income));

            // adding id to the datas so that we can use these id in the monthly reconciliations table.
            for (int i = 0; i < reconciliations.Count; i++)
            {
                reconciliations[i].Id = i + 1;
            }

            for (int i = 0; i < monthlyDatas.Count; i++)
            {
                monthlyDatas[i].Id = i + 1;
            }

            foreach (var monthlyData in monthlyDatas)
            {
                monthlyReconciliations.AddRange(GetMonthlyReconciliations(monthlyData, reconciliations));
            }


            context.monthlyDatas.AddRange(monthlyDatas);
            context.reconciliations.AddRange(reconciliations);
            context.monthlyReconciliations.AddRange(monthlyReconciliations);


        }

        private IList<Reconciliation> GetReconciliations(ReconciliationType type)
        {
            var reconciliations = new List<Reconciliation>();
            for (int i = 0; i < 5; i++)
            {
                reconciliations.Add(new Reconciliation
                {
                    Name = $"Type {i}",
                    Type = type
                });
            }
            return reconciliations;
        }

        private IList<MonthlyData> GetMonthlyDatasForAYear(int year)
        {
            Random rnd = new Random();
            var monthlyDatas = new List<MonthlyData>();
            for (int i = 1; i <= 12; i++)
            {
                var monthlyData = new MonthlyData
                {
                    Year = year,
                    Month = i,
                    Cost = rnd.Next(1, 100),
                    Income = rnd.Next(1, 100),
                };
                monthlyDatas.Add(monthlyData);
            }
            return monthlyDatas;
        }

        private IList<MonthlyReconciliation> GetMonthlyReconciliations(MonthlyData month, IList<Reconciliation> reconciliations)
        {
            var rand = new Random();
            var monthlyReconciliations = new List<MonthlyReconciliation>();
            foreach (var reconciliation in reconciliations)
            {
                monthlyReconciliations.Add(new MonthlyReconciliation
                {
                    MonthlyDataId = month.Id,
                    ReconciliationId = reconciliation.Id,
                    Value = rand.Next(1, 100)
                });
            }
            return monthlyReconciliations;
        }
    }
}
