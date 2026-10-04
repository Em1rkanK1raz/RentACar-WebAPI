using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarWebAPI.Models;

namespace RentACarWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            try
            {
                var cars = _context.Cars.ToList();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddCar(CarCreateDto dto)
        {
            try
            {
                var car = new Car
                {
                    Brand = dto.Brand,
                    Model = dto.Model,
                    Plate = dto.Plate,
                    DailyPrice = dto.DailyPrice,
                    IsRented = false
                };
                _context.Cars.Add(car);
                _context.SaveChanges();
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Araç eklenirken hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, CarCreateDto dto)
        {
            try
            {
                var car = _context.Cars.Find(id);
                if (car == null) return NotFound($"ID {id} olan araç bulunamadı!");

                car.Brand = dto.Brand;
                car.Model = dto.Model;
                car.Plate = dto.Plate;
                car.DailyPrice = dto.DailyPrice;
                car.IsRented = dto.IsRented;

                _context.SaveChanges();
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Araç güncellenirken hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                var car = _context.Cars.Find(id);
                if (car == null) return NotFound($"ID {id} olan araç bulunamadı!");

                _context.Cars.Remove(car);
                _context.SaveChanges();
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Araç silinirken hata oluştu: {ex.Message}");
            }
        }
    }
}   