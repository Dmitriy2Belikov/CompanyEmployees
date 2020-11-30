using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Mediator
{
    public interface IRequestHandler<TRequest, TValue>
        where TRequest : IRequest<TValue>
        where TValue : class
    {
        public TValue Handle(TRequest request);
    }

    public interface IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        public void Handle(TRequest request);
    }
}
