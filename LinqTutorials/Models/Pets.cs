using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Models
{
    public class Pets
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Pets(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
