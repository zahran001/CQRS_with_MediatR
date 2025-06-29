using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
	// all commands and queries must have a handler in the handlers folder

	public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
	{
		// we do have to bring in data access here since we'll be calling it directly
		private readonly IDataAccess _data;

		public InsertPersonHandler(IDataAccess data)
		{
			_data = data;
		}
		public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
		}
	}
}
