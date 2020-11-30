using CompanyEmployees.Core.Domain.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployess.Infrastructure.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Create(string firstName, string lastName, string middleName, string phone, Guid companyId)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Phone = phone,
                CompanyId = companyId
            };

            return employee;
        }
    }
}
