using Microsoft.AspNetCore.Mvc;
using RentACarWebAPI.Models;

namespace RentACarWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _context.Customers.ToList();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerCreateDto dto)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Müşteri eklenirken hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerCreateDto dto)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null) return NotFound($"ID {id} olan müşteri bulunamadı!");

                customer.FirstName = dto.FirstName;
                customer.LastName = dto.LastName;
                customer.PhoneNumber = dto.PhoneNumber;
                customer.Email = dto.Email;
                customer.NationalId = dto.NationalId;

                _context.SaveChanges();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Müşteri güncellenirken hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null) return NotFound($"ID {id} olan müşteri bulunamadı!");

                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Müşteri silinirken hata oluştu: {ex.Message}");
            }
        }
    }
}