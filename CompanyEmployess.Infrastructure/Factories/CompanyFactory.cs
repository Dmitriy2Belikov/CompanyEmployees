using CompanyEmployees.Core.Domain.Model.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployess.Infrastructure.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        public Company Create(string title)
        {
            var company = new Company()
            {
                Id = Guid.NewGuid(),
                Title = title
            };

            return company;
        }
    }
}
