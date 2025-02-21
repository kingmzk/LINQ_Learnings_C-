using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials
{
    public class Programme1
    {
        //public static void mains(string[] args)
        //{
        //    Console.WriteLine("Test");
        //}

        //public static void Run()
        //{
        //    Console.WriteLine("Test");
        //}

        public interface IAnimal
        {
            string Name { get; set; }

            void speak();
        }

        public interface IVehicle
        {
            string Model { get; set; }

            void Drive();
        }

        public class Person : IAnimal
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
            public void speak()
            {
                Console.WriteLine($"{Name} is speaking");
            }
        }

        public class Car : IVehicle
        {
            public string Model { get; set; }
            public Car(string model)
            {
                Model = model;
            }
            public void Drive()
            {
                Console.WriteLine($"{Model} is Driving");
            }
        }


        //OfType (The OfType method in LINQ is used to filter a sequence based on the type of elements it contains.)
        public static void Main(string[] args)
        {
            var objects = new Object[]
            {
               "string1",
               1,
               2,
               "string2",
               3,
               "string3",
               true,
               false,
               1.5,
               2.5
            };

            var stringCollection = objects.OfType<string>();
            var intCollection = objects.OfType<int>();
            var doubleCollection = objects.OfType<double>();
            var boolCollection = objects.OfType<bool>();

            var combinedCollection = stringCollection.Cast<Object>().
                Concat(intCollection.Cast<Object>())
                .Concat(doubleCollection.Cast<Object>())
                .Concat(boolCollection.Cast<Object>());

            foreach (var item in combinedCollection)
            {
                Console.WriteLine($"{item} : {item.GetType().Name}");
            }

            var objectss = new Object[]
            {
                new Person("Buddy"),
                new Car("BMW"),
                new Person("Zakria"),
                new Car("Honda"),
                "RandomString",
                42
            };

            var animals = objectss.OfType<IAnimal>();
            var vehicles = objectss.OfType<IVehicle>();

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} is an animal : {animal.GetType().Name}");
                animal.speak();
            }





            //Distinct (The Distinct method in LINQ is used to remove duplicate elements from a sequence.)

            var numbers = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 10 };
            var distinctNumbers = numbers.Distinct();
            foreach (var number in distinctNumbers)
            {
                Console.WriteLine(number);
            }

            var pets = new List<Pet>
            {
                new Pet (1, "Hannibal", PetType.Fish, 1.1f),
                new Pet (2, "Anthony", PetType.Cat, 2f),
                new Pet (3, "Hannibal", PetType.Fish, 1.1f),
            };

            var collection = new List<List<int>>
            {
                new List<int> { 1, 2, 3,4 } ,  // 0 duplicates
                new List<int> {1,2,3,4,4,4 },  // 3 duplicates
                new List<int> {1,2,3,4,4,4,5,6,7} // 3 duplicates
            };

            var collectionWithMostDuplicates = collection
                .OrderByDescending(x => x.Count() - x.Distinct().Count())
                .ThenByDescending(x => x.Count())
                .FirstOrDefault();

            foreach (var item in collectionWithMostDuplicates)
            {
                Console.WriteLine($"{item}  ");
            }




            // Prepend & Append (The Prepend method in LINQ is used to add an element to the beginning of a sequence, while the Append method is used to add an element to the end of a sequence.)
            var list = new string[] {"good", "bad", "ugly" };
            var newList = list.Prepend("Excellent").Append("Terrible");
            Console.WriteLine(string.Join(", ", newList));



            //Concat & Union (The Concat method in LINQ is used to concatenate two sequences, while the Union method is used to combine two sequences without duplicates.)
            var list1 = new int[] { 1, 2, 3 , 4, 5};
            var list2 = new int[] { 4, 5, 6 , 7, 8};
            var concatedList = list1.Concat(list2);
            var unionList = list1.Union(list2);
            Console.WriteLine(string.Join(", ", concatedList));
            Console.WriteLine(string.Join(", ", unionList));

            var number1 = new List<int> { 1, 2, 3, 4, 5, 9, 16, 19 };
            var number2 = new List<int> { 4, 8, 9, 10, 16, 25 };

            var result = number1.Where(x => Math.Sqrt(x) % 1 == 0).Concat(number2.Where(x => Math.Sqrt(x) % 1 == 0).Distinct().OrderBy(x => x));

            foreach (var item in result)  Console.WriteLine($"{item} is number square");




            //Collection Type Change (The ToArray, ToList, ToHashSet, and ToDictionary methods in LINQ are used to convert a collection to a different type of collection.)
            var numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> numberList = numberArray.ToList();
            var numberArray2 = numberList.ToArray();
            HashSet<int> numberHashSet = numberArray.ToHashSet();
            HashSet<int> numberHashSet2 = numberList.ToHashSet();
            var idToDictionary = pets.ToDictionary(x => x.Id, y => y.Name);  //keys should be unique
            var PetTypeLookUp = pets.ToLookup(x => x.PetType, y => y.Name);  //keys can be duplicated


            Console.WriteLine($"Array : {string.Join(",", numberArray)}");
            Console.WriteLine($"List : {string.Join(",", numberList)}");
            Console.WriteLine($"Array2 : {string.Join(",", numberArray2)}");
            Console.WriteLine($"HashSet : {string.Join(",", numberHashSet)}");
            Console.WriteLine($"HashSet2 : {string.Join(",", numberHashSet2)}");
            foreach (var item in idToDictionary) Console.WriteLine($"{item.Key} : {item.Value}");
            foreach (var item in PetTypeLookUp) Console.WriteLine($"{item.Key} : {string.Join(",", item)}");




            //AsEnumerable Method (The AsEnumerable method in LINQ is used to convert a collection to an enumerable object.)
            var verySpecificList = new VerySpecificList<int> { 1, 2, 2, 2, 1, 3, 3, 4 };
            //var evenNumberFilters = verySpecificList.Where(x => x % 2 == 0); //error
            var evenNumberFilter = verySpecificList.AsEnumerable().Where(x => x % 2 == 0);
            Console.WriteLine($"{string.Join(",", evenNumberFilter)}");



            //Cast (The Cast method in LINQ is used to convert a collection of one type to another type.)
            var numberList2 = new List<int> { 1, 2, 3, 4, 5 };
            //IEnumerable<long> longToInt = numberList2.Cast<long>();
            IEnumerable<long> longToInt = numberList2.Cast<int>().Select(x => (long)x);
            Console.WriteLine($"{string.Join(",", longToInt)}");

            IEnumerable<PetType> petTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();
            Console.WriteLine($"{string.Join(",", petTypes)}");




            //Select (The Select method in LINQ is used to transform a sequence of elements into a new sequence of elements. And also we can change types of elements)
            var selectedDoubleNumbers = numberList2.Select(x => 2 * x);
            Console.WriteLine($"{string.Join(",", selectedDoubleNumbers)}");

            var words = new string[] {"one", "two", "three", "four", "five"};
            var selectedWordsToUpper = words.Select(x => x.ToUpper());
            Console.WriteLine($"{string.Join(",", selectedWordsToUpper)}");

            IEnumerable<string> changeType = numberList2.Select(x => x.ToString());
            foreach (var item in changeType) Console.WriteLine($"{string.Join(",", item + " : " + item.GetType())}");

            var numberedIndexInSelect = words.Select((x,index) => $"{index + 1} : {x}");
            foreach (var item in numberedIndexInSelect) Console.WriteLine($"{item}");
        }
    }


    class VerySpecificList<T> : List<T>
    {
        public IEnumerable<T> Where(Func<T, bool> predicate){
            throw new InvalidOperationException("We dont support filtering here");
            }
    }

}
