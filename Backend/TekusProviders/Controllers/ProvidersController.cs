using Microsoft.AspNetCore.Mvc;
using TekusProviders.Models;
using TekusProviders.Services;

namespace TekusProviders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
        {
            return Ok(await _providerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProviderById(Guid id)
        {
            var provider = await _providerService.GetById(id);
            if (provider == null)
                return NotFound();

            return Ok(provider);
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            var newProvider = await _providerService.Add(provider);
            return CreatedAtAction(nameof(GetProviderById), new { id = newProvider.Id }, newProvider);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(Guid id, Provider provider)
        {
            if (id != provider.Id)
                return BadRequest();

            await _providerService.Update(provider);
            return NoContent();
        }
    }
}
