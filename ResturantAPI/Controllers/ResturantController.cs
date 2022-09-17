using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Dtos;
using ResturantAPI.Services;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            return Ok(_resturantService.Get(Id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_resturantService.GetAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateResturantDto dto)
        {
            return Ok(_resturantService.Create(dto));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateResturantDto dto)
        {
            return Ok(_resturantService.Update(dto));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _resturantService.Delete(Id);
            return Ok("Deleted");
        }
    }
}
