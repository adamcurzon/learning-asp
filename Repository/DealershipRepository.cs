using System;
using System.Linq;
using learning_asp.Data;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Model
{
	public class DealershipRepository : ControllerBase
	{
        private ApplicationDbContext _context;

        public DealershipRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<ActionResult<List<Car>>> GetCars() {
            return await _context.Cars.ToListAsync();
        }

        public async Task<ActionResult<List<Car>>> CreateCar(Car car) {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        public Car? GetCarById(int id) {
            return _context.Cars.Where(n => n.Id == id).FirstOrDefault();
        }

        public Car? GetCarBySku(string sku)
        {
            return _context.Cars.Where(n => n.CarSku == sku).FirstOrDefault();
        }

        public bool DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return true;
        }

        public int? GetCarLastId() {
            var lastCar = _context.Cars.OrderBy(e => e.Id).LastOrDefault();

            if (lastCar == null)
                return null;

            if (lastCar.Id.HasValue)
                return lastCar.Id.Value;

            return null;
        }
    }
}