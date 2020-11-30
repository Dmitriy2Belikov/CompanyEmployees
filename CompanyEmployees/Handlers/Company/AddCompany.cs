using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Dtos.CompanyDtos;
using CompanyEmployees.Dtos.CompanyDtos.Builder;
using CompanyEmployees.Dtos.CompanyDtos.Forms;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Company
{
    public class AddCompany : IRequest<CompanyDto>
    {
        public AddCompanyForm AddCompanyForm { get; set; }
    }

    public class AddCompanyHandler : IRequestHandler<AddCompany, CompanyDto>
    {
        private readonly ICompanyFactory companyFactory;
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyDtoBuilder companyDtoBuilder;

        public AddCompanyHandler(
            ICompanyFactory companyFactory, 
            ICompanyRepository companyRepository,
            ICompanyDtoBuilder companyDtoBuilder)
        {
            this.companyFactory = companyFactory;
            this.companyRepository = companyRepository;
            this.companyDtoBuilder = companyDtoBuilder;
        }

        public CompanyDto Handle(AddCompany request)
        {
            var company = companyFactory.Create(request.AddCompanyForm.Title);

            companyRepository.Add(company);

            companyRepository.SaveChanges();

            var companyDto = companyDtoBuilder.Build(company);

            return companyDto;
        }
    }
}
