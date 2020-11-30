using CompanyEmployees.Core.Domain.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Dtos.CompanyDtos.Builder
{
    public interface ICompanyDtoBuilder
    {
        public CompanyDto Build(Company company);
    }
}
