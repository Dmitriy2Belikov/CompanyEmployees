using CompanyEmployees.Core.Domain.Model.Employee;
using CompanyEmployees.Exceptions;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Employee
{
    public class RemoveEmployee : IRequest
    {
        public Guid Id { get; set; }
    }

    public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployee>
    {
        private readonly IEmployeeRepository employeeRepository;

        public RemoveEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Handle(RemoveEmployee request)
        {
            var employee = employeeRepository.Find(request.Id);

            if (employee == null) throw new NotFoundException();

            employeeRepository.Remove(employee);

            employeeRepository.SaveChanges();
        }
    }
}
