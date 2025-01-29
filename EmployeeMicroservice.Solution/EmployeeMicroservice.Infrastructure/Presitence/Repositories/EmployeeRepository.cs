using EmployeeMicroservice.Application.Interfaces;
using EmployeeMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Infrastructure.Presitence.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context):IEmployeeRepository
    {
        private readonly ApplicationDbContext _context=context;

        public async Task AddAsync(Employee employee)=>await _context.Employees.AddAsync(employee);
       
        public async Task DeleteAsync(Employee employee) => _context.Employees.Remove(employee);
       
        public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();
       

        public async Task<Employee?> GetByIdAsync(int id)=>await _context.Employees.FindAsync(id);
        

        public async Task UpdateAsync(Employee employee)=>_context.Entry(employee).State = EntityState.Modified;

       
        
    }
}
