using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Dtos;
using ResturantAPI.Services;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantMenuController : ControllerBase
    {
        private readonly IResturantMenuService _resturantMenuService;

        public ResturantMenuController(IResturantMenuService resturantMenuService)
        {
            _resturantMenuService = resturantMenuService;
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            return Ok(_resturantMenuService.Get(Id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_resturantMenuService.GetAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateResturantMenuDto dto)
        {
            return Ok(_resturantMenuService.Create(dto));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateResturantMenuDto dto)
        {
            return Ok(_resturantMenuService.Update(dto));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _resturantMenuService.Delete(Id);
            return Ok("Deleted");
        }
    }
}
