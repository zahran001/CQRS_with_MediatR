using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
	public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel> // has to be a query or a command in this spot
	{
		private readonly IMediator _mediator;

		public GetPersonByIdHandler(IMediator mediator)
        {
			_mediator = mediator;
		}
        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
		{
			// Directly querying the database for a single record is more efficient than retrieving all records and filtering for one.

			// For learning purposes:
			// Demonstrates the concept of a MediatR handler invoking another MediatR request.


			var results = await _mediator.Send(new GetPersonListQuery());

			var output = results.FirstOrDefault(x => x.Id == request.Id); // request.Id comes from the request where you passed in that data

			return output;

		}
	}
}
