using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Comparator
{
    public class PetByTypeComparer : IComparer<Pet>  //orderBy
    {
        public int Compare(Pet? x, Pet? y)
        {
            return x.PetType.CompareTo(y.PetType);
        }
    }
}
