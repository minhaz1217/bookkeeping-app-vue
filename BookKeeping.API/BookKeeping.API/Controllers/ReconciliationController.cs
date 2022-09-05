using BookKeeping.Service.Models;
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
            try
            {
                return Ok(await _reconciliationService.GetReconciliations(year));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save-reconciliation-data")]
        public async Task<IActionResult> SaveReconciliationData(YearModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _reconciliationService.SaveReconciliationDataAsync(model));
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
