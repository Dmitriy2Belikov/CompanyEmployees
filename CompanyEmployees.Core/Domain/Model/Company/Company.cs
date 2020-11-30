using CompanyEmployees.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployees.Core.Domain.Model.Company
{
    public class Company : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee.Employee> Employees { get; set; }

        public Company UpdateTitle(string title)
        {
            Title = title;

            return this;
        }
    }
}
