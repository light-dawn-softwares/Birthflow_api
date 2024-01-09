using Birthflow_api.Application.Dto;
using Birthflow_api.Application.Interfaces;
using Birthflow_api.Application.Services;
using Birthflow_api.Infrastructure.Models;
using Birthflow_api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Birthflow_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartographController : ControllerBase
    {
        private readonly PartographService _partographService;
        private readonly WorkTimeService _workTimeService;
        private readonly CervicalDilationService _cervicalDilationService;
        private readonly MedicalSurveillanceService _medicalSurveillanceService;
        private readonly VppService _vppService;

        public PartographController(PartographService partographService, WorkTimeService workTimeService, 
            CervicalDilationService cervicalDilationService, MedicalSurveillanceService medicalSurveillanceService, VppService vppService)
        {
            _partographService = partographService;
            _workTimeService = workTimeService;
            _cervicalDilationService = cervicalDilationService;
            _medicalSurveillanceService = medicalSurveillanceService;
            _vppService = vppService;
        }

        #region General
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
                var partograph = _partographService.findById(partographId);

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

        #endregion

        #region WorkTime
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

        #endregion

        [HttpGet("cervicalDilation/{partographId}")]
        public IActionResult Get(string partographId)
        {
            try
            {
                var result = _cervicalDilationService.GetByPartograph(partographId);
                return Ok(result);
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        [HttpPost("cervicalDilation/{partographId}")]
        public IActionResult Create(string partographId, [FromBody] CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                _cervicalDilationService.Create(cervicalDilationDto);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("cervicalDilation/{cervicalDilationId}")]
        public IActionResult Update(int cervicalDilationId, [FromBody] CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                _cervicalDilationService.Update(cervicalDilationDto);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("cervicalDilation/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cervicalDilationService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region MedicalSUrveillance 

        [HttpGet("MedicalSurveillance/{partographId}")]
        public IActionResult GetByPartographId(string partographId)
        {
            try
            {
                var result = _medicalSurveillanceService.GetByPartographId(partographId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("MedicalSurveillance/item/{medicalSurveillanceId}")]
        public IActionResult GetMedicalSurveillanceById(int medicalSurveillanceId)
        {
            try
            {
                var result =_medicalSurveillanceService.GetMedicalSurveillanceById(medicalSurveillanceId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("MedicalSurveillance/")]
        public IActionResult CreateMedicalSurveillance([FromBody] MedicalSurveillanceDto medicalSurveillanceDto)
        {
            try
            {
                _medicalSurveillanceService.Create(medicalSurveillanceDto);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("MedicalSurveillance/{medicalSurveillanceId}")]
        public IActionResult UpdateMedicalSurveillance(int medicalSurveillanceId, [FromBody] MedicalSurveillanceDto medicalSurveillanceDto )
        {
            try
            {
                var result = _medicalSurveillanceService.GetMedicalSurveillanceById(medicalSurveillanceId );
                
                if (result == null)
                    return NotFound();

                _medicalSurveillanceService.Update(medicalSurveillanceDto);
                return CreatedAtAction(nameof(GetMedicalSurveillanceById), new { medicalSurveillanceId = medicalSurveillanceDto.MedicalSurveillanceId }, medicalSurveillanceDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("MedicalSurveillance/{id}")]
        public IActionResult DeleteMedicalSurveillace(int id)
        {
            try
            {
                _medicalSurveillanceService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Vpp

        [HttpGet("Vpp/{partographId}")]
        public IActionResult VppGetByPartographId(string partographId)
        {
            try
            {
                var result = _vppService.GetVppsByPartograph(partographId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Vpp/item/{vvpId}")]
        public IActionResult GetVppById(int vvpId)
        {
            try
            {
                var result = _vppService.GetVppById(vvpId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("Vvp/")]
        public IActionResult CreateVpp([FromBody] VppDto vppDto)
        {
            try
            {
                _vppService.Create(vppDto);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("MedicalSurveillance/{vppId}")]
        public IActionResult UpdateVpp(int vppId, [FromBody] VppDto vppDto)
        {
            try
            {
                var result = _vppService.GetVppById(vppId);

                if (result == null)
                    return NotFound();

                _vppService.Update(vppDto);
                return CreatedAtAction(nameof(GetVppById), new { vppId = vppDto.VppId }, vppDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("Vpp/{id}")]
        public IActionResult DeleteVpp(int id)
        {
            try
            {
                _vppService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
