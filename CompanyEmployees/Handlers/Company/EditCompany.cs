using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Dtos.CompanyDtos;
using CompanyEmployees.Dtos.CompanyDtos.Builder;
using CompanyEmployees.Dtos.CompanyDtos.Forms;
using CompanyEmployees.Exceptions;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Company
{
    public class EditCompany : IRequest<CompanyDto>
    {
        public Guid Id { get; set; }
        public EditCompanyForm EditCompanyForm;
    }

    public class EditCompanyHandler : IRequestHandler<EditCompany, CompanyDto>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyDtoBuilder companyDtoBuilder;

        public EditCompanyHandler(ICompanyRepository companyRepository, ICompanyDtoBuilder companyDtoBuilder)
        {
            this.companyRepository = companyRepository;
            this.companyDtoBuilder = companyDtoBuilder;
        }

        public CompanyDto Handle(EditCompany request)
        {
            var company = companyRepository.Find(request.Id);

            if (company == null) throw new NotFoundException();

            company.UpdateTitle(request.EditCompanyForm.Title);

            companyRepository.Update(company);

            companyRepository.SaveChanges();

            var companyDto = companyDtoBuilder.Build(company);

            return companyDto;
        }
    }
}
