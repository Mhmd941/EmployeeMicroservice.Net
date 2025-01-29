using EmployeeMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Application.Interfaces
{
    public interface IEmployeeRepository
    {


        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);


        Task DeleteAsync(Employee employee);



        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        
        
    }
}
