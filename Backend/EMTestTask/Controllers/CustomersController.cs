using EMTestTask.Models;
using EMTestTask.Sevices;
using EMTestTask.Validator;
using Microsoft.AspNetCore.Mvc;

namespace EMTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService) =>
            _customersService = customersService;

        [HttpGet]
        public async Task<List<Customer>> Get() =>
            await _customersService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Customer newCustomer)
        {
            if (!CustomerValidator.IsValidName(newCustomer.FirstName) || !CustomerValidator.IsValidName(newCustomer.SecondName))
                return BadRequest(new { message = "Invalid First or Second Name!" });

            if (!CustomerValidator.IsValidEmail(newCustomer.Email))
                return BadRequest(new { message = "Invalid Email!" });

            if (!CustomerValidator.IsValidPhoneNumber(newCustomer.PhoneNumber))
                return BadRequest(new { message = "Invalid Number!" });

            if (await _customersService.EmailExistsAsync(newCustomer.Email))
                return Conflict(new { message = "The following email already exists!" });

            if (await _customersService.PhoneExistsAsync(newCustomer.PhoneNumber))
                return Conflict(new { message = "The following phone number already exists!" });

            await _customersService.CreateAsync(newCustomer);
            return CreatedAtAction(nameof(Get), new { id = newCustomer.Id }, newCustomer);
        }
    }
}
