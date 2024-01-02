using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Application.Services;
using Birthflow_api.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Birthflow_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartographController : ControllerBase
    {
        private readonly PartographService _partographService;
        private readonly WorkTimeService _workTimeService;

        public PartographController(PartographService partographService, WorkTimeService workTimeService)
        {
            _partographService = partographService;
            _workTimeService = workTimeService;
        }


        [HttpGet]
        [Route("GetPartographs")]
        public IActionResult GetPartographs(Guid UserId)
        {
            var result = _partographService.GetAll(UserId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePartograph([FromBody] PartographCreateDto partographDto)
        {
            try
            {
                _partographService.create(partographDto);
                return NoContent();
              
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPut("{partographId}")]
        public IActionResult UpdatePartograph(string partographId, [FromBody] PartographDto partographDto)
        {
            try
            {
                var existingUser = _partographService.findById(partographId);

                if (existingUser == null)
                    return NotFound();

                _partographService.update(partographDto);

                return CreatedAtAction(nameof(FindPartograph), new { partographId = partographDto.PartographId }, partographDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{partographId}")]
        public IActionResult FindPartograph(string partographId)
        {
            try
            {
                var partograph =_partographService.findById(partographId);
                
                if (partograph == null)
                    return NotFound();

                return Ok(partograph);    
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{partographId}")]
        public IActionResult DeleteUser(string partographId)
        {
            try
            {
                var existingUser = _partographService.findById(partographId);

                if (existingUser == null)
                    return NotFound();

                _partographService.delete(partographId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("worktime/{partographId}")]
        public IActionResult FindWorkTime(string partographId)
        {
            try
            {
                var partograph = _workTimeService.FindById(partographId);

                if (partograph == null)
                    return NotFound();

                return Ok(partograph);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("worktime/{partographId}")]
        public IActionResult UpdateWorkTime(string partographId, [FromBody] WorkTimeDto workTimeDto)
        {
            try
            {
                var existing = _workTimeService.FindById(partographId);

                if (existing == null)
                    return NotFound();

                _workTimeService.Update(workTimeDto);

                return CreatedAtAction(nameof(FindWorkTime), new { partographId = workTimeDto.PartographId }, workTimeDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
