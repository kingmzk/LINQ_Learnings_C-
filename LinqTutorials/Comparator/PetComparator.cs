using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Comparator
{
    public class PetComparatorById : IEqualityComparer<Pet>  //Contains
    {
        public bool Equals(Pet x, Pet y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Pet obj)
        {
            // return base.GetHashCode();
            return obj.Id;
        }
    }
}
