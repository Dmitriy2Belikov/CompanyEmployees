using CompanyEmployees.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployess.Infrastructure.Repositories
{
    public class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyContext context) : base(context)
        {
        }
    }
}
