using Microsoft.EntityFrameworkCore;

namespace GBCSporting_OJO.Models
{
    public class GBCSporting_OJOContext : DbContext
    {
        public GBCSporting_OJOContext(DbContextOptions<GBCSporting_OJOContext> options)
            : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Technicians> Technicians { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    CustomerId = 1,
                    CustomerFirstName = "Janine",
                    CustomerLastName = "Usana",
                    CustomerAddress = "Test Street",
                    CustomerCity = "Toronto",
                    CustomerState = "Ontario",
                    CustomerCountry = "Canada",
                    CustomerEmail = "janine.maeusana@georgebrown.ca",
                    CustomerPhone = "666-666-6666",
                },
                new Customers
                {
                    CustomerId = 2,
                    CustomerFirstName = "Omar",
                    CustomerLastName = "Nabi",
                    CustomerAddress = "Test Avenue",
                    CustomerCity = "New York",
                    CustomerState = "NY",
                    CustomerCountry = "USA",
                    CustomerEmail = "omar.nabi@georgebrown.ca",
                    CustomerPhone = "666-666-6666",
                }

            );

            modelBuilder.Entity<Technicians>().HasData(
                new Technicians
                {
                    TechnicianId = 1,
                    TechnicianName = "Otavio Barbosa",
                    TechnicianEmail = "otavio.pereirabarbosa@georgebrown.ca",
                    TechnicianPhone = "647-562-3407"
                },
                new Technicians
                {
                    TechnicianId = 2,
                    TechnicianName = "Roger Gracie",
                    TechnicianEmail = "test@test.com",
                    TechnicianPhone = "647-562-3407"
                }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1,
                    ProductCode = "1Sport",
                    ProductName = "Sport One - Team Management",
                    ProductPrice = "29.99",
                    ProductReleaseDate = DateTime.Today
                }
            );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    TechnicianId = 1,
                    IncidentTitle = "Fix Login",
                    IncidentDescription = "Create separated logins for users and admins",
                    IncidentDateOpened = DateTime.Today,
                    IncidentDateClosed = DateTime.Today,
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 2,
                    ProductId = 1,
                    TechnicianId = 2,
                    IncidentTitle = "Change overall theme",
                    IncidentDescription = "Updated the whole visual",
                    IncidentDateOpened = DateTime.Today
                }
            );
        }

    }
}
