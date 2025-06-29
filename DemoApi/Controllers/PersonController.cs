using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
			_mediator = mediator;
        }
		// GET: api/<PersonController>
		[HttpGet]
		// used singleton
		public async Task<List<PersonModel>> Get() => await _mediator.Send(new GetPersonListQuery());
		// Arrow function (=>): Short, single-expression methods - a concise way to write a method or property that returns a single expression.
		// The => syntax means "return the result of this expression."

		// GET api/<PersonController>/5
		[HttpGet("{id}")]
		public async Task<PersonModel> Get(int id)
		{
			return await _mediator.Send(new GetPersonByIdQuery(id)); // can use arrow function here as well
		}

		// POST api/<PersonController>
		[HttpPost]
		public async Task<PersonModel> Post([FromBody] PersonModel value)
		{
			var model = new InsertPersonCommand(value.FirstName, value.LastName);
			return await _mediator.Send(model);
		}

	}
}
