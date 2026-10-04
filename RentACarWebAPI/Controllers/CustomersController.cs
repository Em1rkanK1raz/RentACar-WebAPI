using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarWebAPI.Models;

namespace RentACarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersController(AppDbContext context)
        {
            _context = context;

        }
        private readonly AppDbContext _context;
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpPost]

        public IActionResult AddCustomer(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                NationalId = dto.NationalId
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerCreateDto dto)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.Email = dto.Email;
            customer.NationalId = dto.NationalId;
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id) {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
