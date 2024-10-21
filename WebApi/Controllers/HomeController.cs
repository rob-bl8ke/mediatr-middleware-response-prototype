using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Commands;
using Services.Models;
using Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cars")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Car>> GetCars()
        {
            return mediator.Send(new GetAllCarsQuery());
        }

        /// <summary>
        /// You can test this using something like Postman
        /// POST https://localhost:44344/cars
        /// </summary>
        [HttpPost]
        public Task<Response<Car>> CreateCar()
        {
            return mediator.Send(new CreateCarCommand());
        }
    }
}
