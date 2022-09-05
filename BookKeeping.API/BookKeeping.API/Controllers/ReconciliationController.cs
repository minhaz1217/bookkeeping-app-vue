using BookKeeping.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookKeeping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationController : ControllerBase
    {
        private readonly IMonthlyDataService _monthlyDataService;
        private readonly IReconciliationService _reconciliationService;
        public ReconciliationController(
            IMonthlyDataService monthlyDataService,
            IReconciliationService reconciliationService)
        {
            _monthlyDataService = monthlyDataService;
            _reconciliationService = reconciliationService;
        }

        [HttpGet("get-reconciliation-by-year")]
        public async Task<IActionResult> GetById(int year, int? month)
        {
            return Ok(await _reconciliationService.GetReconciliations(year));
            return Ok(await _monthlyDataService.GetMonthlyDatas(year, month));
        }

        //public IActionResult GetYearlyData(int year)
        //{

        //}
    }
}
