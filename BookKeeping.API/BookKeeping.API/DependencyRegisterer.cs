using BookKeeping.API.Controllers;
using BookKeeping.Domain.Data;
using BookKeeping.Domain.Models;
using BookKeeping.Repository;
using BookKeeping.Repository.Repositories;
using BookKeeping.Service.Services;

namespace BookKeeping.API
{
    public static class DependencyRegisterer
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<BookKeepingContext, BookKeepingContext>();
            
            builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            builder.Services.AddSingleton<IMonthlyDataService, MonthlyDataService>();
            
            builder.Services.AddSingleton<IMonthlyDataRepository, MonthlyDataRepository>();
            builder.Services.AddSingleton<IReconciliationService, ReconciliationService>();
            builder.Services.AddSingleton<IReconciliationRepository, ReconciliationRepository>();
            builder.Services.AddSingleton<IMonthlyReconciliationRepository, MonthlyReconciliationRepository>();
        }
    }
}
