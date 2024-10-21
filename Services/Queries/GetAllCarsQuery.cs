using MediatR;
using System.Linq;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class GetAllCarsQuery : IRequest<IEnumerable<Car>>
    {
    }

    // IRequestHandler<Unit, ...> <---- if returning nothing
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        // do dependency injection here
        public GetAllCarsQueryHandler()
        {

        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = new []
            {
                new Car{ Name = "Ferrari" },
                new Car{ Name = "Ford" }
            };
            return await Task.FromResult(cars);
        }
    }
}
