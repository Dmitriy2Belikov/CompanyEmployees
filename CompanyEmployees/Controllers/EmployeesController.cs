using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyEmployees.Dtos.EmployeeDtos;
using CompanyEmployees.Dtos.EmployeeDtos.Forms;
using CompanyEmployees.Handlers.Employee;
using CompanyEmployees.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseAppController
    {
        [HttpPost]
        public IActionResult Create(AddEmployeeForm addEmployeeForm)
        {
            var employee = Mediator.Send<AddEmployee, EmployeeDto>(new AddEmployee() 
            { 
                AddEmployeeForm = addEmployeeForm 
            });

            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetPaged(int pagenumber = 1, int pagesize = 20)
        {
            var employees = Mediator.Send<GetPagedEmployees, EntityPage<EmployeeDto>>(new GetPagedEmployees() 
            { 
                PageNumber = pagenumber, 
                PageSize = pagesize
            });

            return Ok(employees);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, EditEmployeeForm editEmployeeForm)
        {
            var employee = Mediator.Send<EditEmployee, EmployeeDto>(new EditEmployee() 
            { 
                Id = id, 
                EditEmployeeForm = editEmployeeForm 
            });

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            Mediator.Send(new RemoveEmployee() 
            { 
                Id = id 
            });

            return NoContent();
        }
    }
}
