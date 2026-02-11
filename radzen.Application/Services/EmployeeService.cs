using radzen.Application.Contracts;
using radzen.Application.DTO;
using radzen.Domain.Entities;
using System.Net.Http.Json;

namespace radzen.Application.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var data = await httpClient.PostAsJsonAsync("api/Employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await httpClient.DeleteAsync($"api/employee/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<List<Employee>> GetAsync()=>
            await httpClient.GetFromJsonAsync<List<Employee>>("api/Employee")!;


        public async Task<Employee> GetByIdAsync(int id) =>
            await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}")!;



        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var data = await httpClient.PutAsJsonAsync("api/Employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
