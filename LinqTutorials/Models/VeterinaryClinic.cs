using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Models
{
    public class VeterinaryClinic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public VeterinaryClinic() {}

        public VeterinaryClinic(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
