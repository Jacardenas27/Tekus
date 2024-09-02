using Microsoft.AspNetCore.Mvc;
using TekusProviders.Models;
using TekusProviders.Services;

namespace TekusProviders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return Ok(await _serviceService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(Guid id)
        {
            var service = await _serviceService.GetById(id);
            if (service == null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            var newService = await _serviceService.Add(service);
            return CreatedAtAction(nameof(GetService), new { id = newService.Id }, newService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(Guid id, Service service)
        {
            if (id != service.Id)
                return BadRequest();

            await _serviceService.Update(service);
            return NoContent();
        }
    }
}
