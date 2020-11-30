using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyEmployees.Core.Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
