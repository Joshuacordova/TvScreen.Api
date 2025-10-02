using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TVScreen.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly ILogger<FilterController> _logger;
        private readonly IScheduleService _scheduleService;
        public FilterController(ILogger<FilterController> logger, IScheduleService scheduleService)
        {
            _logger = logger;
            _scheduleService = scheduleService;
        }

        [HttpGet("GetScheduleContent")]
        public async Task<IActionResult> GetScheduleContent(string filter, int startPage, int lastPage)
        {
            var scheduleMovieOrChannel = await _scheduleService.GetAllSchedule(filter, startPage, lastPage);
            return Ok(scheduleMovieOrChannel);
        }
    }
}
