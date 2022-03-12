using EmployeeApp.Data.Dtos;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployee(Employee model);
        Task<Employee> GetEmployee(string empId);
        Task<bool> UpdateEmployee(Employee newEmployee);
        Task<bool> DeleteEmployee(Employee employee);
        Task<List<Employee>> GetEmployees();
        //Task<Employee> GetCategory(string CategoryId);
        Task<bool> SaveChanges();

    }
}
