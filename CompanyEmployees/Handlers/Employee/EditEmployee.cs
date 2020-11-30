using CompanyEmployees.Core.Domain.Model.Employee;
using CompanyEmployees.Dtos.EmployeeDtos;
using CompanyEmployees.Dtos.EmployeeDtos.Builder;
using CompanyEmployees.Dtos.EmployeeDtos.Forms;
using CompanyEmployees.Exceptions;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Employee
{
    public class EditEmployee : IRequest<EmployeeDto>
    {
        public Guid Id { get; set; }
        public EditEmployeeForm EditEmployeeForm { get; set; }
    }

    public class EditEmployeeHandler : IRequestHandler<EditEmployee, EmployeeDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeDtoBuilder employeeDtoBuilder;

        public EditEmployeeHandler(IEmployeeRepository employeeRepository, IEmployeeDtoBuilder employeeDtoBuilder)
        {
            this.employeeRepository = employeeRepository;
            this.employeeDtoBuilder = employeeDtoBuilder;
        }

        public EmployeeDto Handle(EditEmployee request)
        {
            var employee = employeeRepository.Find(request.Id);

            if (employee == null) throw new NotFoundException();

            employee.FirstName = request.EditEmployeeForm.FirstName;
            employee.LastName = request.EditEmployeeForm.LastName;
            employee.MiddleName = request.EditEmployeeForm.MiddleName;
            employee.Phone = request.EditEmployeeForm.Phone;
            employee.CompanyId = request.EditEmployeeForm.CompanyId;

            employeeRepository.Update(employee);

            employeeRepository.SaveChanges();

            var employeeDto = employeeDtoBuilder.Build(employee);

            return employeeDto;
        }
    }
}
