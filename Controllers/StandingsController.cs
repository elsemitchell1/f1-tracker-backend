using Microsoft.AspNetCore.Mvc;
using F1TrackerApi.Services;

namespace F1TrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StandingsController : ControllerBase
    {
        private readonly ErgastApiService _ergastService;

        public StandingsController(ErgastApiService ergastService)
        {
            _ergastService = ergastService;
        }

        [HttpGet("currentDriver")]
        public async Task<IActionResult> GetCurrentStandings()
        {
            var data = await _ergastService.GetCurrentStandingsAsync();
            return Content(data, "application/json");
        }
        [HttpGet("currentConstructor")]
        public async Task<IActionResult> GetCurrentConstructorStandings()
        {
            var data = await _ergastService.GetCurrentConstructorStandingsAsync();
            return Content(data, "application/json");
        }
    }
}