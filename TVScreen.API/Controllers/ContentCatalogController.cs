using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace TVScreen.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentCatalogController : ControllerBase
    {
        private readonly ILogger<ContentCatalogController> _logger;
        private readonly IContentCatalogService _contentCatalogService;
        public ContentCatalogController(ILogger<ContentCatalogController> logger, IContentCatalogService contentCatalogService)
        {
            _logger = logger;
            _contentCatalogService = contentCatalogService;
        }


        [HttpGet("FindCatalog")]
        public async Task<IActionResult> FindCatalog(Guid uid)
        {
            var catalog = await _contentCatalogService.GetContentCatalogByGuid(uid);
            return Ok(catalog);
        }

        [HttpGet("GetAllCatalog")]
        public async Task<IActionResult> GetAllCatalog(int startPage, int lastPage)
        {
            return Ok(await _contentCatalogService.GetAllContentCatalog(startPage, lastPage));
        }

        [HttpPost("CreateCatalog")]
        public async Task<IActionResult> CreateCatalog([FromBody] ContentCatalogDto contentCatalogDto)
        {
            await _contentCatalogService.CreateContentCatalog(contentCatalogDto);
            return Ok();
        }

        [HttpPut("UpdateCatalog")]
        public async Task<IActionResult> UpdateCatalog([FromBody] ContentCatalogDto contentCatalogDto)
        {
            await _contentCatalogService.UpdateContentCatalog(contentCatalogDto);
            return Ok();
        }

        [HttpDelete("DeleteCatalog")]
        public async Task<IActionResult> DeleteCatalog(Guid uid)
        {
            var contentCatalog = await _contentCatalogService.GetContentCatalogByGuid(uid);
            await _contentCatalogService.DeleteContetnCatalog(contentCatalog);

            return Ok();
        }

    }
}
