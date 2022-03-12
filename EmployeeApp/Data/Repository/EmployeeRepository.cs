using EmployeeApp.Data.Dtos;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEmployee(Employee model)
        {
            await _context.Employees.AddAsync(model);

            return await SaveChanges();
        }

        public Task<bool> DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            return SaveChanges();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(string empId)
        {

            return await _context.Employees.Where(e => e.Id == empId).FirstOrDefaultAsync();
               
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployee(Employee newEmployee)
        {
            _context.Employees.Update(newEmployee);
            return await SaveChanges();
        }
    }
}
