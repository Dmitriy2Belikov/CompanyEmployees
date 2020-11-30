using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Dtos.CompanyDtos;
using CompanyEmployees.Dtos.CompanyDtos.Builder;
using CompanyEmployees.Helpers;
using CompanyEmployees.Mediator;
using System.Collections.Generic;
using System.Linq;

namespace CompanyEmployees.Handlers.Company
{
    public class GetPagedCompanies : IRequest<EntityPage<CompanyDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPagedCompaniesHandler : IRequestHandler<GetPagedCompanies, EntityPage<CompanyDto>>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyDtoBuilder companyDtoBuilder;

        public GetPagedCompaniesHandler(ICompanyRepository companyRepository, ICompanyDtoBuilder companyDtoBuilder)
        {
            this.companyRepository = companyRepository;
            this.companyDtoBuilder = companyDtoBuilder;
        }

        public EntityPage<CompanyDto> Handle(GetPagedCompanies request)
        {
            var companies = companyRepository.PagedList(request.PageNumber, request.PageSize);

            if (companies != null)
            {
                var companyPage = companies.Select(x => companyDtoBuilder.Build(x));
                var pageCount = companies.PageCount;

                var entityPage = new EntityPage<CompanyDto>(companyPage, request.PageNumber, pageCount);

                return entityPage;
            }

            return new EntityPage<CompanyDto>(new List<CompanyDto>(), request.PageNumber, 0);
        }
    }
}
