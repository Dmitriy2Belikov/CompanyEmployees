using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Dtos.CompanyDtos;
using CompanyEmployees.Dtos.CompanyDtos.Builder;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Company
{
    public class GetAllCompanies : IRequest<IEnumerable<CompanyDto>>
    {

    }

    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompanies, IEnumerable<CompanyDto>>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyDtoBuilder companyDtoBuilder;

        public GetAllCompaniesHandler(ICompanyRepository companyRepository, ICompanyDtoBuilder companyDtoBuilder)
        {
            this.companyRepository = companyRepository;
            this.companyDtoBuilder = companyDtoBuilder;
        }

        public IEnumerable<CompanyDto> Handle(GetAllCompanies request)
        {
            var companies = companyRepository.List();

            var companyDtos = companies.Select(c => companyDtoBuilder.Build(c));

            return companyDtos;
        }
    }
}
