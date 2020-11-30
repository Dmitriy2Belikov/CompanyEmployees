using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployees.Core.Domain.Model.Company
{
    public interface ICompanyFactory
    {
        public Company Create(string title);
    }
}
