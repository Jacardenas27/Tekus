using Microsoft.AspNetCore.Mvc;
using TekusProviders.Models;
using TekusProviders.Services;

namespace TekusProviders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsServiceCountryController : ControllerBase
    {
        private readonly IDetailsServiceCountryService _service;

        public DetailsServiceCountryController(IDetailsServiceCountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsServiceCountry>>> GetDetailsServiceCities()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsServiceCountry>> GetDetailsServiceCity(Guid id)
        {
            var detailsServiceCity = await _service.GetById(id);
            if (detailsServiceCity == null)
                return NotFound();

            return Ok(detailsServiceCity);
        }

        [HttpPost]
        public async Task<ActionResult<DetailsServiceCountry>> PostDetailsServiceCity(DetailsServiceCountry detailsServiceCity)
        {
            var newDetailsServiceCity = await _service.Add(detailsServiceCity);
            return CreatedAtAction(nameof(GetDetailsServiceCity), new { id = newDetailsServiceCity.Id }, newDetailsServiceCity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailsServiceCity(Guid id, DetailsServiceCountry detailsServiceCity)
        {
            if (id != detailsServiceCity.Id)
                return BadRequest();

            await _service.Update(detailsServiceCity);
            return NoContent();
        }

        [HttpGet("completeDetails")]
        public async Task<ActionResult<IEnumerable<DetailsServiceCountry>>> GetDetailsWithService()
        {
            return Ok(await _service.GetDetailsWithService());
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return Ok(await _service.GetCountriesFromExternalApi());
        }
    }
}
