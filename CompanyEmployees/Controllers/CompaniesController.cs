using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyEmployees.Dtos.CompanyDtos;
using CompanyEmployees.Dtos.CompanyDtos.Forms;
using CompanyEmployees.Handlers.Company;
using CompanyEmployees.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseAppController
    {
        [HttpPost]
        public IActionResult Create(AddCompanyForm addCompanyForm)
        {
            var company = Mediator.Send<AddCompany, CompanyDto>(new AddCompany() 
            { 
                AddCompanyForm = addCompanyForm 
            });

            return Ok(company);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var companies = Mediator.Send<GetAllCompanies, IEnumerable<CompanyDto>>(new GetAllCompanies());

            return Ok(companies);
        }

        [HttpGet]
        public IActionResult GetPaged([FromQuery]int pagenumber = 1, [FromQuery]int pagesize = 20)
        {
            var companies = Mediator.Send<GetPagedCompanies, EntityPage<CompanyDto>>(new GetPagedCompanies() 
            { 
                PageNumber = pagenumber,
                PageSize = pagesize
            });

            return Ok(companies);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, EditCompanyForm editCompanyForm)
        {
            var company = Mediator.Send<EditCompany, CompanyDto>(new EditCompany() 
            { 
                Id = id, 
                EditCompanyForm = editCompanyForm 
            });

            return Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            Mediator.Send(new RemoveCompany() { Id = id });

            return NoContent();
        }
    }
}
