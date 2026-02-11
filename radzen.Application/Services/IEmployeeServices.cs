

using radzen.Application.DTO;
using radzen.Domain.Entities;

namespace radzen.Application.Services
{
    public interface IEmployeeServices
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
