using AutoMapper;
using EmployeeMicroservice.Application.DTOs;
using EmployeeMicroservice.Application.Interfaces;
using EmployeeMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper) : IEmployeeService
    {

        private readonly IEmployeeRepository _repository = employeeRepository;
        private readonly IMapper _mapper = mapper;
        public async Task AddEmployeeAsync(CreateEmployeeDto CreateEmployeeDto)=> await _repository.AddAsync(_mapper.Map<Employee>(CreateEmployeeDto));

     
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee=await _repository.GetByIdAsync(id);
            if (employee is null) return;

            await _repository.DeleteAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        { 


          var employees= await _repository.GetAllAsync();

          return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            
        }

        public async Task<EmployeeDto?> GetEmployeeById(int id)
        {
            
            
            var employee= await _repository.GetByIdAsync(id);


            return _mapper.Map<EmployeeDto?>(employee);

        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            
            var employee=_mapper.Map<Employee>(updateEmployeeDto);

            await _repository.UpdateAsync(employee);
        }
    }
}
