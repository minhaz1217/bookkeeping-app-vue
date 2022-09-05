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
        public ReconciliationController(IMonthlyDataService monthlyDataService)
        {
            _monthlyDataService = monthlyDataService;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _monthlyDataService.GetByIDAsync(id));
        }
    }
}
