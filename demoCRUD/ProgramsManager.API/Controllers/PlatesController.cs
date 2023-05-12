using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models;

namespace ProgramsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatesController : ControllerBase
    {
        private readonly IServices<PlateDto> _platesService;
        public PlatesController(IServices<PlateDto> platesService)
        {
            _platesService = platesService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<PlateDto> plates = await _platesService.GetAsync();

            if (plates.Any())
            {
                return Ok(plates); 
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            PlateDto PlateDto = await _platesService.GetAsync(id);
            if (PlateDto is not null)
            {
                return Ok(PlateDto);
            }
           
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PlateDto PlateDto)
        {
            PlateDto PlateDtoCreated = await _platesService.CreateAsync(PlateDto);

            if (PlateDtoCreated is not null)
            {
                return Created(nameof(CreateAsync), PlateDtoCreated);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PlateDto PlateDto)
        {
            PlateDto PlateDtoUpdated = await _platesService.UpdateAsync(id, PlateDto);

            if (PlateDtoUpdated is not null)
            {
                return Ok(PlateDtoUpdated);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            PlateDto PlateDtoDeleted = await _platesService.DeleteAsync(id);

            if (PlateDtoDeleted is not null) 
            {
                return Ok(PlateDtoDeleted); 
            }

            return NotFound();
        }
    }
}
