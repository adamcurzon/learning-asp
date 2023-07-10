using System;
using learning_asp.Data;
using learning_asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace learning_asp.Repository
{
	public class UserRepository : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Car>>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreateUser", new { id = user.Id }, user);
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.Where(n => n.Email == email).FirstOrDefault();
        }
    }
}

