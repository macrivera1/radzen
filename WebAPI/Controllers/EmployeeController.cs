using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using radzen.Application.Contracts;
using radzen.Application.DTO;
using radzen.Domain.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;


        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await employee.GetAsync();
            return Ok(data);
        }
        //PUT
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await employee.GetByIdAsync(id);
            return Ok(data);
        }
        //POSTTT
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employeeDTO)
        {
            ServiceResponse result = await employee.AddAsync(employeeDTO);
            return Ok(result);
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDTO){
            var result = await employee.UpdateAsync(employeeDTO);
            return Ok(result);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await employee.DeleteAsync(id);
            return Ok(result);
        }
    }
}
