using CompanyEmployees.Core.Domain.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployess.Infrastructure.Repositories
{
    public class CompanyRepository : EFRepository<Company> , ICompanyRepository
    {
        public CompanyRepository(CompanyContext context) : base(context)
        {
        }
    }
}
