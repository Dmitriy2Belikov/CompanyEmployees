using CompanyEmployees.Core.Domain.Model.Company;
using CompanyEmployees.Core.Domain.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployess.Infrastructure
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
