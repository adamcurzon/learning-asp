
using learning_asp.Model;

namespace learning_asp.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    CarName = "Ford Fiesa",
                    CarSku = "fordfiesta",
                    CarColour = "Silver",
                },
                new Car
                {
                    Id = 2,
                    CarName = "BMW M140",
                    CarSku = "bmwm140",
                    CarColour = "Grey",
                }
            );
        }
    }
}

