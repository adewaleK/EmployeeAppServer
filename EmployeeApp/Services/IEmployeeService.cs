using EmployeeApp.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        Task<(bool, string, EmployeeToReturnDto)> AddEmployee(EmployeeToAddDto model);
        Task<EmployeeToReturnDto> GetEmployeeByIdAsync(string employeeId);
        Task<List<EmployeeToReturnDto>> GetAllEmployeesAsync();
        Task<bool> DeleteEmployee(string id);
        Task<EmployeeToReturnDto> UpdateEmployeeByIdAsync(string categoryId, EmployeeToAddDto newEmployee);
    }
}
