using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.Interfaces;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService) {
            _customersService = customersService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _customersService.GetCustomer(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customersService.GetAllCustomers();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var result = _customersService.AddCustomer(customer);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var result = _customersService.UpdateCustomer(customer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _customersService.DeleteCustomer(id);
            return Ok(result);
        }

    }
}