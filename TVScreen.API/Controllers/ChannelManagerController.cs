using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TVScreen.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChannelManagerController : ControllerBase
    {
        private readonly ILogger<ChannelManagerController> _logger;
        private readonly IChannelManagerService _channelManagerService;
        public ChannelManagerController(ILogger<ChannelManagerController> logger, IChannelManagerService channelManagerService)
        {
            _logger = logger;
            _channelManagerService = channelManagerService;
        }

        [HttpGet("GetAllTvChannels")]
        public async Task<IActionResult> GetAllTvChannels(int startPage, int lastPage)
        {
            var channelList = await _channelManagerService.GetAllTvChannels(startPage, lastPage);
            return Ok(channelList);
        }

        [HttpPost("CreateChannels")]
        public async Task<IActionResult> CreateChannelManager([FromBody] Application.DTOs.ChannelManagerDto channelManagerDto)
        {
            await _channelManagerService.CreateChannelManager(channelManagerDto);
            return Ok("Success");
        }
    }
}
