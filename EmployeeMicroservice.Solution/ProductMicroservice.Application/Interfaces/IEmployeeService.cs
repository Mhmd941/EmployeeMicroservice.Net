using EmployeeMicroservice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Application.Interfaces
{
    public interface IEmployeeService
    {

        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

        Task<EmployeeDto?> GetEmployeeById(int id);

        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);

        Task DeleteEmployeeAsync(int id);

        Task AddEmployeeAsync(CreateEmployeeDto CreateEmployeeDto);
    }
}
