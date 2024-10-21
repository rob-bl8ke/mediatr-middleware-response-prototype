using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Commands
{
    public class CreateCarCommand : BaseRequest, IRequest<string>
    {
        public CreateCarCommand()
        {
            // from middleware... see UserIdPipe
            // However it is NOT available at this point... so good to initialize values???
            Console.WriteLine(base.UserId);
        }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, string>
    {
        public async Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            //
            // At this point your Middleware data will be available...
            Console.WriteLine(request.UserId);

            return await Task.FromResult("Response Data");
        }
    }
}
