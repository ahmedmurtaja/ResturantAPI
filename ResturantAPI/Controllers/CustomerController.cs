using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Dtos;
using ResturantAPI.Services;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            return Ok(_customerService.Get(Id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateCustomerDto dto)
        {
            return Ok(_customerService.Create(dto));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateCustomerDto dto)
        {
            return Ok(_customerService.Update(dto));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _customerService.Delete(Id);
            return Ok("Deleted");
        }

    }
}
