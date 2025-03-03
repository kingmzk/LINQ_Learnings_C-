using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Models
{
    public class Persons
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }

        public Persons() { }
        public Persons(string name, List<string> pets)
        {
            Name = name;
            Pets = pets;
        }
    }
}
