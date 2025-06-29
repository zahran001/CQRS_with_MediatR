using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Queries
{
	/* 
	 * Records are classes with additional syntax goodness.
	 
	 * A record is a special reference type introduced in C# 9.0 that is designed to simplify
		* the creation of immutable data objects. Records are ideal for representing 
		* data models, especially in scenarios like APIs, messaging, or configuration.
	 
	 * By default, records are immutable (especially with init-only setters).
	 
	 * Two records with the same values are considered equal (unlike classes).
	 */

	// IRequest - is for your queries and commands
	public record GetPersonListQuery() : IRequest<List<PersonModel>>;
	
	//public class GetPersonListQueryClass : IRequest<List<PersonModel>>
	//{
	//}
}
