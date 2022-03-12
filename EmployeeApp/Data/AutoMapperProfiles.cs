using AutoMapper;
using EmployeeApp.Data.Dtos;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeToAddDto>().ReverseMap();
            CreateMap<EmployeeToReturnDto, Employee>().ReverseMap();
        }
      
    }
}
