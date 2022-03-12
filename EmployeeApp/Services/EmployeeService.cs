using AutoMapper;
using EmployeeApp.Data.Dtos;
using EmployeeApp.Data.Repository;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeyRepository, IMapper mapper)
        {
            _employeeRepository = employeeyRepository;
            _mapper = mapper;
        }
        public async Task<(bool, string, EmployeeToReturnDto)> AddEmployee(EmployeeToAddDto model)
        {
            var employeeToadd = _mapper.Map<Employee>(model);

            var response = await _employeeRepository.AddEmployee(employeeToadd);
            if (!response)
                return (false, "Employee could not be added", null);
            var data = _mapper.Map<EmployeeToReturnDto>(employeeToadd);

            return (true, "Category Succesfully Added", data);
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null) return false;

            var deletetEmp = _employeeRepository.DeleteEmployee(employee);
            if (deletetEmp == null) return false;

            return true;
        }

        public async Task<List<EmployeeToReturnDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployees();
            if (employees == null) return null;
            var employeeToReturn = _mapper.Map<List<EmployeeToReturnDto>>(employees);
            return employeeToReturn;

        }

        public async Task<EmployeeToReturnDto> GetEmployeeByIdAsync(string employeeId)
        {
            var employee = await _employeeRepository.GetEmployee(employeeId);

            if (employee == null) return null;

            var employeeToReturn = _mapper.Map<EmployeeToReturnDto>(employee);

            return employeeToReturn;
        }

        public async Task<EmployeeToReturnDto> UpdateEmployeeByIdAsync(string empId, EmployeeToAddDto newEmployee)
        {
            var employeeToUpdate = await _employeeRepository.GetEmployee(empId);

            employeeToUpdate.FirstName = newEmployee.FirstName;
            employeeToUpdate.LastName = newEmployee.LastName;
            employeeToUpdate.PhoneNmber = newEmployee.PhoneNmber;
            employeeToUpdate.Address = newEmployee.Address;
            employeeToUpdate.Salary = newEmployee.Salary;

            var response = await _employeeRepository.UpdateEmployee(employeeToUpdate);

            if (!response) return null;

            var updatedEmployee = _mapper.Map<EmployeeToReturnDto>(employeeToUpdate);

            return updatedEmployee;
        }
    }
}
