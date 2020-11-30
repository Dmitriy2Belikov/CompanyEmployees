using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Не найдено") { }
    }
}
