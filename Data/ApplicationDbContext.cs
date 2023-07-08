
using System;
using learning_asp.Model;
using Microsoft.EntityFrameworkCore;

namespace learning_asp.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Car> Cars { get; set; }
	}
}

