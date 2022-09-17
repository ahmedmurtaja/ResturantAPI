using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Dtos;
using ResturantAPI.Services;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;

        public OrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            return Ok(_customerOrderService.GetOrderById(Id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_customerOrderService.GetAllOrders());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateCustomerOrderDto dto)
        {
            return Ok(_customerOrderService.Order(dto));
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateCustomerOrderDto dto)
        {
            return Ok(_customerOrderService.UpdateOrder(dto));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _customerOrderService.DeleteOrder(Id);
            return Ok("Deleted");
        }
    }
}
