using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarWebAPI.Models;

namespace RentACarWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllRentals()
        {
            try
            {
                var rentals = _context.Rentals
                    .Include(r => r.Car)
                    .Include(r => r.Customer)
                    .ToList();

                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult RentCar(RentalCreateDto dto)
        {
            try
            {
                var car = _context.Cars.Find(dto.CarId);
                if (car == null) return NotFound("Seçilen araç bulunamadı!");

                var customer = _context.Customers.Find(dto.CustomerId);
                if (customer == null) return NotFound("Seçilen müşteri bulunamadı!");

                if (car.IsRented)
                {
                    return BadRequest("Bu araç şu anda başka bir müşteride kirada! Kiralanamaz.");
                }

                if (dto.EndDate <= dto.StartDate)
                {
                    return BadRequest("Bitiş tarihi başlangıç tarihinden sonra olmalıdır!");
                }

                int rentalDays = (dto.EndDate.Date - dto.StartDate.Date).Days;
                if (rentalDays == 0) rentalDays = 1;

                decimal totalPrice = rentalDays * car.DailyPrice;

                var rental = new Rental
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    TotalPrice = totalPrice
                };

                car.IsRented = true;

                _context.Rentals.Add(rental);
                _context.SaveChanges();

                return Ok(new
                {
                    Message = "Araç başarıyla kiralandı!",
                    RentalId = rental.Id,
                    TotalPrice = totalPrice,
                    Days = rentalDays
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Kiralama işlemi sırasında hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("return/{carId}")]
        public IActionResult ReturnCar(int carId)
        {
            try
            {
                var car = _context.Cars.Find(carId);
                if (car == null) return NotFound("Araç bulunamadı!");

                if (!car.IsRented)
                {
                    return BadRequest("Bu araç zaten kirada değil!");
                }

                car.IsRented = false;
                _context.SaveChanges();

                return Ok($"{car.Brand} {car.Model} başarıyla teslim alındı ve tekrar müsait duruma getirildi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Teslim alma sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}