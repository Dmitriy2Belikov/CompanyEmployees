using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployees.Core.Domain.Model.Employee
{
    public interface IEmployeeFactory
    {
        public Employee Create(string firstName, string lastName, string middleName, string phone, Guid companyId);
    }
}
