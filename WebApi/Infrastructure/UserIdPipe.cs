using MediatR;
using Microsoft.AspNetCore.Http;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Infrastructure
{
    //
    // This is essentially, middleware
    // Will be injected in Startup
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext httpContext;

        //
        // In order to use HttpContextAccessor see Startup.cs - services.AddHttpContextAccessor();
        public UserIdPipe(IHttpContextAccessor accessor)
        {
            this.httpContext = accessor.HttpContext;
        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, 
            RequestHandlerDelegate<TOut> next)
        {
            // Set a default if nothing available
            string userId = "Anonymous";

            // Fetch from HTTP context
            if (httpContext.User != null && httpContext.User.Claims.Any(c => c.Type.Equals(ClaimTypes.NameIdentifier)))
            {
                userId = httpContext.User.Claims
                    .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                    .Value;
            }


            if (request is BaseRequest br)
            {
                br.UserId = userId;
            }

            return await next();
        }
    }
}
