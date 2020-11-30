using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Mediator
{
    public interface IRequest<TValue>
        where TValue : class
    {

    }

    public interface IRequest
    {

    }
}
