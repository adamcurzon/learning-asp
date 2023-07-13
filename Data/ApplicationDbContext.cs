
using learning_asp.Model;
using Microsoft.AspNetCore.Identity;

namespace learning_asp.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "adam@example.com",
                    Name = "Adam Curzon",
                    Password = BCrypt.Net.BCrypt.HashPassword("password"),
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = Guid.NewGuid(),
                    CarName = "Ford Fiesta",
                    CarSku = "fordfiesta",
                    CarColour = "Silver",
                    CarEngineSize = "1.1",
                    CarEngineType = "Petrol",
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    CarName = "BMW M140",
                    CarSku = "bmwm140",
                    CarColour = "Grey",
                    CarEngineSize = "3.0",
                    CarEngineType = "Petrol",
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    CarName = "Land Rover",
                    CarSku = "lrg",
                    CarColour = "Green",
                    CarEngineSize = "2.2",
                    CarEngineType = "Diesel",
                }
            );
        }
    }
}

