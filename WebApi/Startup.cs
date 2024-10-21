using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Queries;
using WebApi.Infrastructure;

namespace WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 
            // In order to get to HttpContext via UserIdPipe
            services.AddHttpContextAccessor();

            //
            // A bit weird but this is how you'd inject a generic interface (for your pipe)
            // You could obviously stack these pipes up.
            // Order processed is from top to bottom and is important if one relies on another
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AnotherPipe<,>));
            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(YetAnotherPipe<,>));


            //
            // Made possible by MediatR.Extensions.Microsoft.DependencyInjection package.
            // Point to one class within your MediatR service assembly so MediatR knows
            // where to find it.
            services.AddMediatR(typeof(GetAllCarsQuery).Assembly);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
