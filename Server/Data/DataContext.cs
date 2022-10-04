
namespace CRUD_WEBAPI_BLAZOR.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Ferrari", Country = "Italy" },
                new Manufacturer { Id = 2, Name = "Lamborghini", Country = "Italy" },
                new Manufacturer { Id = 3, Name = "Porsche", Country = "Germany" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Model = "488 PISTA",
                    Engine = "V8 TWIN TURBO",
                    Color = "Red",
                    Year = 2022,
                    ManufacturerId = 1
                },
                new Car
                {
                    Id = 2,
                    Model = "AVENTADOR",
                    Engine = "V12",
                    Color = "White",
                    Year = 2021,
                    ManufacturerId = 2
                },
                new Car
                {
                    Id = 3,
                    Model = "Carrera GT",
                    Engine = "V10",
                    Color = "Silver",
                    Year = 2006,
                    ManufacturerId = 3
                }
            );
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
