using Microsoft.AspNetCore.Mvc;
using RentACarWebAPI.Models;

namespace RentACarWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        public CarsController(AppDbContext context)
        {
            _context = context;

        }
        private readonly AppDbContext _context;
        [HttpGet]

        public IActionResult GetAllCars()
        {
            var cars = _context.Cars.ToList();
            return Ok(cars);

        }
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car updatedCar)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Plate = updatedCar.Plate;
            car.DailyPrice = updatedCar.DailyPrice;
            car.IsRented = updatedCar.IsRented;
            _context.SaveChanges();
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok(car);
        }


    }
}