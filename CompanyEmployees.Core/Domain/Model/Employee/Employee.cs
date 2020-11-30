using CompanyEmployees.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployees.Core.Domain.Model.Employee
{
    public class Employee : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public Guid CompanyId { get; set; }

        public Company.Company Company { get; set; }
    }
}
