using EmployeeMicroservice.Application.DTOs;
using EmployeeMicroservice.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _service=employeeService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _service.GetAllEmployeesAsync());


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {

            var employee = await _service.GetEmployeeById(id);
            if (employee is null) return NotFound();

            return Ok(employee);


        }
        [HttpDelete("{id:int}")]
        
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {

            var employee=await _service.GetEmployeeById(id);

            if (employee is null) return NotFound();


            await _service.DeleteEmployeeAsync(id);

            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateEmployeeDto employeeDto)
        {

            await _service.AddEmployeeAsync(employeeDto);

            return Ok("Employee has been added successfully");


        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateAsync([FromRoute] int id,[FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var employee=await _service.GetEmployeeById(id);

            if(employee is null) return NotFound();


            await _service.UpdateEmployeeAsync(updateEmployeeDto);

            return NoContent();

        }

        




    }
}
