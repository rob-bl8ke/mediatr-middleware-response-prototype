using MediatR;
using Services.Models;
using Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Commands
{
    public class CreateCarCommand : BaseRequest, IRequestWrapper<Car>
    {
        public CreateCarCommand()
        {
            // from middleware... see UserIdPipe
            // However it is NOT available at this point... so good to initialize values???
            Console.WriteLine(base.UserId);
        }
    }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Car>
    {
        public async Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            //
            // At this point your Middleware data will be available...
            Console.WriteLine(request.UserId);

            var success = true;

            if (!success)
            {
                return await Task.FromResult(Response.Fail<Car>("Failed get create a car."));
            }

            return await Task.FromResult(Response.Ok<Car>(new Car { Name = "New Car" }, "Successfully created new car"));
        }
    }
}
