using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_WEBAPI_BLAZOR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CarController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            var cars = await _dataContext.Cars.Include(m => m.Manufacturer).ToListAsync();
            return Ok(cars);
        }

        [HttpGet("manufacturers")]
        public async Task<ActionResult<List<Car>>> GetManufacturers()
        {
            var manufacturers = await _dataContext.Manufacturers.ToListAsync();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetSingleCar(int id)
        {
            var car = await _dataContext.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(car => car.Id == id);
            if (car == null)
                return NotFound("Sorry, no car here");
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> CreateCar(Car car)
        {
            car.Manufacturer = null;
            _dataContext.Cars.Add(car);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetDbCars());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car car, int id)
        {
            var dbCar = await _dataContext.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbCar == null)
                return NotFound("Sorry bro, no car here");

            dbCar.Model = car.Model;
            dbCar.Engine = car.Engine;
            dbCar.Color = car.Color;    
            dbCar.Year = car.Year;
            dbCar.ManufacturerId = car.ManufacturerId;

            await _dataContext.SaveChangesAsync();
            return Ok(await GetDbCars());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Car>>> DeleteCar(int id)
        {
            var dbCar = await _dataContext.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbCar == null)
                return NotFound("Sorry bro, no car here");

            _dataContext.Cars.Remove(dbCar);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDbCars());
        }

        private async Task<List<Car>> GetDbCars()
        {
            return await _dataContext.Cars.Include(m => m.Manufacturer).ToListAsync();
        }

    }
}
