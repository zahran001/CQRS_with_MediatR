using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Commands
{
	public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;
	// record
	// here FirstName and LastName are not traditional parameters - they're going to create properties based upon these names



	
	// class equivalent
	//public class InsertPersonCommandClass : IRequest<PersonModel>
	//{
	//	public string FirstName { get; set; }
	//	public string LastName { get; set; }

 //       public InsertPersonCommandClass(string firstName, string lastName)
 //       {
	//		FirstName = firstName;
	//		LastName = lastName;
            
 //       }
 //   }
}
