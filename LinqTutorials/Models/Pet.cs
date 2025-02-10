using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Models
{
    public class Pet : IComparable<Pet> //comparable due to Min or Max
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public float weight { get; set; }

        public Pet(int id, string name, PetType petType, float weight)
        {
            this.Id = id;
            this.Name = name;
            this.PetType = petType;
            this.weight = weight;
        }

        public int CompareTo(Pet? other)
        {
           return weight.CompareTo(other.weight);
        }
    }
}
