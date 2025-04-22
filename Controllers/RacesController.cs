using Microsoft.AspNetCore.Mvc;
using F1TrackerApi.Services;

namespace F1TrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly ErgastApiService _ergastService;

        public RacesController(ErgastApiService ergastService)
        {
            _ergastService = ergastService;
        }
        [HttpGet("Results")]
        public async Task<IActionResult> GetCurrentRaceResults()
        {
            var data = await _ergastService.GetCurrentRaceResultsAsync();
            return Content(data, "application/json");
        }
    }
}