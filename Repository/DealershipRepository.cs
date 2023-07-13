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
            return await _context.Cars.OrderByDescending(i => i.CreatedDate).ToListAsync();
        }

        public async Task<bool> CreateCar(Car car) {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public Car? GetCarById(Guid id) {
            return _context.Cars.Where(n => n.Id == id).FirstOrDefault();
        }

        public bool DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return true;
        }

        public int GetTotalCars() {
            return _context.Cars.Count();
        }
    }
}