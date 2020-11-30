using CompanyEmployees.Core.Domain.Model.Employee;
using CompanyEmployees.Dtos.EmployeeDtos;
using CompanyEmployees.Dtos.EmployeeDtos.Builder;
using CompanyEmployees.Dtos.EmployeeDtos.Forms;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Employee
{
    public class AddEmployee : IRequest<EmployeeDto>
    {
        public AddEmployeeForm AddEmployeeForm { get; set; }
    }

    public class AddEmployeeHandler : IRequestHandler<AddEmployee, EmployeeDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeFactory employeeFactory;
        private readonly IEmployeeDtoBuilder employeeDtoBuilder;

        public AddEmployeeHandler(
            IEmployeeRepository employeeRepository, 
            IEmployeeFactory employeeFactory, 
            IEmployeeDtoBuilder employeeDtoBuilder)
        {
            this.employeeRepository = employeeRepository;
            this.employeeFactory = employeeFactory;
            this.employeeDtoBuilder = employeeDtoBuilder;
        }

        public EmployeeDto Handle(AddEmployee request)
        {
            var employee = employeeFactory.Create(
                request.AddEmployeeForm.FirstName,
                request.AddEmployeeForm.LastName,
                request.AddEmployeeForm.MiddleName,
                request.AddEmployeeForm.Phone,
                request.AddEmployeeForm.CompanyId);

            employeeRepository.Add(employee);

            employeeRepository.SaveChanges();

            var employeeDto = employeeDtoBuilder.Build(employee);

            return employeeDto;
        }
    }
}
