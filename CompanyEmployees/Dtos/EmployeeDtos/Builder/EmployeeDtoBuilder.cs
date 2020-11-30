using CompanyEmployees.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Dtos.EmployeeDtos.Builder
{
    public class EmployeeDtoBuilder : IEmployeeDtoBuilder
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDtoBuilder(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public EmployeeDto Build(Employee employee)
        {
            employeeRepository.Load(employee, e => e.Company);

            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Phone = employee.Phone,
                Company = employee.Company.Title
            };

            return employeeDto;
        }
    }
}
