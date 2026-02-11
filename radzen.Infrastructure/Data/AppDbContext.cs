using Microsoft.EntityFrameworkCore;
using radzen.Domain.Entities;
namespace radzen.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }


    } 
}
