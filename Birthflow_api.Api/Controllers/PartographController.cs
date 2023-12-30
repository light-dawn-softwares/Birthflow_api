using Birthflow_api.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Birthflow_api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartographController : ControllerBase
    {
        private readonly PartographService _partographService;

        public PartographController(PartographService partographService)
        {
            _partographService = partographService;
        }


        [HttpGet]
        [Route("GetPartographs")]
        public IActionResult GetPartographs([FromBody] string UserId)
        {
            var result = _partographService.GetAll(UserId);
            return Ok(result);
        }

    }
}
