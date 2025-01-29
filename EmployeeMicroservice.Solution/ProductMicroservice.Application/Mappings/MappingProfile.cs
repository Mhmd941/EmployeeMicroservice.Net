using AutoMapper;
using EmployeeMicroservice.Application.DTOs;
using EmployeeMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Application.Mappings
{
    public class MappingProfile:Profile
    {

        public MappingProfile() { 
        
        
            CreateMap<EmployeeDto,Employee>().ReverseMap();

            CreateMap<CreateEmployeeDto,Employee>().ReverseMap();

            CreateMap<UpdateEmployeeDto,Employee>().ReverseMap();

        }
    }
}
