using Microsoft.EntityFrameworkCore;
using radzen.Application.Contracts;
using radzen.Application.DTO;
using radzen.Domain.Entities;
using radzen.Infrastructure.Data;

namespace radzen.Infrastructure.Implementations
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            await SaveChangesAsync();

            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return new ServiceResponse(false, "User Not Found");
            }
            else
            {
                appDbContext.Employees.Remove(employee);
                await SaveChangesAsync();
                return new ServiceResponse(true, "User Deleted");
            }
        
        }

     

        public async Task<List<Employee>> GetAsync() => await appDbContext.Employees.AsNoTracking().ToListAsync();


        public async Task<Employee> GetByIdAsync(int id) => await appDbContext.Employees.FindAsync(id);

       

        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            appDbContext.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");

        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync(); 
    }
}
