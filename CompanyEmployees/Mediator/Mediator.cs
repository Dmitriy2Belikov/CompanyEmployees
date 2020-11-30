using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Mediator
{
    public class Mediator : IMediator
    {
        private IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TValue Send<TRequest, TValue>(TRequest request) 
            where TRequest : IRequest<TValue>
            where TValue : class
        {
            var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest, TValue>>();

            var result = handler.Handle(request);

            return result;
        }

        public void Send<TRequest>(TRequest request)
            where TRequest : IRequest
        {
            var handler = serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();

            handler.Handle(request);
        }
    }
}
