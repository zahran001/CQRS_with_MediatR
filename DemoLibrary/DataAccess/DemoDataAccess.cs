using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "John", LastName = "Doe" });
            people.Add(new PersonModel { Id = 2, FirstName = "Tim", LastName = "Carry" });
        }

        // 2 methods
        // implement GetPeople method
        public List<PersonModel> GetPeople()
        {
            return people;
        }

        // implement InsertPerson method
        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }
    }
}
