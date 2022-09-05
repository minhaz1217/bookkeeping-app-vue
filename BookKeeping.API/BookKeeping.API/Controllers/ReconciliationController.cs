using BookKeeping.Service.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("get-reconciliations-by-year")]
        public async Task<IActionResult> GetById(int year)
        {
            return Ok(await _reconciliationService.GetReconciliations(year));
        }
    }
}
