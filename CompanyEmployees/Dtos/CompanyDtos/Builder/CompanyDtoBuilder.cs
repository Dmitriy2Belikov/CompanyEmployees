using CompanyEmployees.Core.Domain.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Dtos.CompanyDtos.Builder
{
    public class CompanyDtoBuilder : ICompanyDtoBuilder
    {
        public CompanyDto Build(Company company)
        {
            var companyDto = new CompanyDto()
            {
                Id = company.Id,
                Title = company.Title
            };

            return companyDto;
        }
    }
}
