using CompanyEmployees.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Dtos.EmployeeDtos.Builder
{
    public interface IEmployeeDtoBuilder
    {
        public EmployeeDto Build(Employee employee);
    }
}
