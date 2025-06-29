using DemoLibrary.DataAccess;
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
	// GetPersonListQuery - what you're going to handle
	// List<PersonModel> - what you're going to return (output the value)
	public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
	{

		private readonly IDataAccess _data;

		// ctor 
		// mediatR does not replace DI - it just adds to / improves it
        public GetPersonListHandler(IDataAccess data)
        {
			_data = data;
        }

		// everything is asynchronous in mediatR - so you need to return a Task<T> or Task
		// cancellation token is optional, but it's a good practice to include it
		public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_data.GetPeople());
			// GetPeople() method will get that list of people and return that in the handler.
			// Now our handler knows about our data access.
		}
	}
}

// GetPeople() returns a List<PersonModel>
// Each PersonModel has properties such as FirstName and LastName.
// The actual retrieval of names (and other data) happens inside the implementation of IDataAccess (DemoDataAccess). 
