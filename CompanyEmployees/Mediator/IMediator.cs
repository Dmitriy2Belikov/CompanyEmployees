using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Mediator
{
    public interface IMediator
    {
        public TValue Send<TRequest, TValue>(TRequest request)
            where TRequest : IRequest<TValue>
            where TValue : class;

        public void Send<TRequest>(TRequest request)
            where TRequest : IRequest;
    }
}
