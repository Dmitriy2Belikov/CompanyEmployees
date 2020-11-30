using CompanyEmployees.Core.Domain.Model.Employee;
using CompanyEmployees.Dtos.EmployeeDtos;
using CompanyEmployees.Dtos.EmployeeDtos.Builder;
using CompanyEmployees.Helpers;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Employee
{
    public class GetPagedEmployees : IRequest<EntityPage<EmployeeDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPagedEmployeesHandler : IRequestHandler<GetPagedEmployees, EntityPage<EmployeeDto>>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeDtoBuilder employeeDtoBuilder;

        public GetPagedEmployeesHandler(IEmployeeRepository employeeRepository, IEmployeeDtoBuilder employeeDtoBuilder)
        {
            this.employeeRepository = employeeRepository;
            this.employeeDtoBuilder = employeeDtoBuilder;
        }

        public EntityPage<EmployeeDto> Handle(GetPagedEmployees request)
        {
            var employees = employeeRepository.PagedList(request.PageNumber, request.PageSize);

            if (employees != null)
            {
                var employeePage = employees.Select(x => employeeDtoBuilder.Build(x));
                var pageCount = employees.PageCount;

                var entityPage = new EntityPage<EmployeeDto>(employeePage, request.PageNumber, pageCount);

                return entityPage;
            }

            return new EntityPage<EmployeeDto>(new List<EmployeeDto>(), request.PageNumber, 0);
        }
    }
}
