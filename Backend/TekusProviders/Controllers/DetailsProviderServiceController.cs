using Microsoft.AspNetCore.Mvc;
using TekusProviders.Models;
using TekusProviders.Services;

namespace TekusProviders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsProviderServiceController : ControllerBase
    {
        private readonly IDetailsProviderServiceService _service;

        public DetailsProviderServiceController(IDetailsProviderServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsProviderService>>> GetDetailsProviderServices()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsProviderService>> GetDetailsProviderService(Guid id)
        {
            var detailsProviderService = await _service.GetById(id);
            if (detailsProviderService == null)
                return NotFound();

            return Ok(detailsProviderService);
        }

        [HttpPost]
        public async Task<ActionResult<DetailsProviderService>> PostDetailsProviderService(DetailsProviderService detailsProviderService)
        {
            var newDetailsProviderService = await _service.Add(detailsProviderService);
            return CreatedAtAction(nameof(GetDetailsProviderService), new { id = newDetailsProviderService.Id }, newDetailsProviderService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailsProviderService(Guid id, DetailsProviderService detailsProviderService)
        {
            if (id != detailsProviderService.Id)
                return BadRequest();

            await _service.Update(detailsProviderService);
            return NoContent();
        }

        [HttpGet("completeDetails")]
        public async Task<ActionResult<IEnumerable<DetailsProviderService>>> GetDetailsWithProvidersAndServices()
        {
            return Ok(await _service.GetDetailsWithProvidersAndServices());
        }
    }
}
