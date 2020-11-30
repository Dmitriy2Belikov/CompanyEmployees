using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Exceptions;
using CompanyEmployees.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Handlers.Company
{
    public class RemoveCompany : IRequest
    {
        public Guid Id { get; set; }
    }

    public class RemoveCompanyHandler : IRequestHandler<RemoveCompany>
    {
        private readonly ICompanyRepository companyRepository;

        public RemoveCompanyHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public void Handle(RemoveCompany request)
        {
            var company = companyRepository.Find(request.Id);

            if (company == null) throw new NotFoundException();

            companyRepository.Remove(company);

            companyRepository.SaveChanges();
        }
    }
}
