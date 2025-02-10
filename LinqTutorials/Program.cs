using LinqTutorials.Comparator;
using LinqTutorials.Models;

namespace LinqTutorials
{
    // Extension method to count the number of line in a string
    public static class StringExtensions
    {
        public static int GetCountOfLines(this string input)
        {
            return input.Split('\n').Length;
        }
    }

    public class Program
    {
        public static void Printer(bool value, string name)
        {
            Console.WriteLine($"{name} is {value}");
        }
        // Utility method: Check if any number is larger than 100
        private static bool IsAnyLargerThan100(int[] numbers)
        {
            return numbers.Any(x => x > 100);
        }

        // Utility method: Check if any number is even
        private static bool IsAnyEven(int[] numbers)
        {
            return numbers.Any(x => x % 2 == 0);
        }

        // Predicate function: Check if a number is larger than 100
        private static bool IsLargerThan100(int number)
        {
            return number > 100;
        }

        // Predicate function: Check if a number is even
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Generic method: Check if any number matches the given predicate
        private static bool IsAny(int[] numbers, Func<int, bool> predicate)
        {
            foreach (var number in numbers)
            {
                if (predicate(number)) // Call the predicate with the current number
                {
                    return true;
                }
            }
            return false;
        }
        //TODO implement this method
        public static bool AreAllNamesValid_Refactored(string[] names)
        {
            return !names.Any(x => char.IsLower(x[0]) || x.Length < 2 || x.Length > 25);
        }

        public static bool AreAllWordsOfTheSameLength_Refactored(List<string> words)
        {
            //if(words != null && words.Count > 0) { return true; }
            var firstWordLength =   words[0].Length;
            return words.All(x => x.Length == firstWordLength);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var list = new string[]
            {
                "ARINA", "KINGMZK", "KINGMZK"
            };

            var ans = isUpperCase(list);
            Console.WriteLine($"Are all strings uppercase? {ans}");

            static Boolean isUpperCase(IEnumerable<string> list)
            {
                //bool isUpperCase = true;

                //foreach(var res in list)
                //{
                //    if(res != null && res.Any(char.IsLower))
                //    { 
                //            isUpperCase = false;
                //    }
                //}
                //return isUpperCase;

                return list.Any(x => x.All(letter => char.IsUpper(letter)));
            }

            var numbers = new[] { 1, 2, 3, 4, 99, 256, 2, 9, 21 };
            // Using LINQ methods directly
            bool isAnyLargerThan100 = numbers.Any(x => x > 100); // LINQ's Any
            Console.WriteLine($"(LINQ) Is any number larger than 100? {isAnyLargerThan100}");

            bool isAnyEven = numbers.Any(x => x % 2 == 0); // LINQ's Any
            Console.WriteLine($"(LINQ) Is any number even? {isAnyEven}");

            // Using custom generic method with lambda predicates
            Console.WriteLine($"(Custom) Is any number larger than 100? {IsAny(numbers, x => x > 100)}");
            Console.WriteLine($"(Custom) Is any number even? {IsAny(numbers, x => x % 2 == 0)}");

            // Using predefined predicate functions with the IsAny method
            Console.WriteLine($"(Custom/Function) Is any number larger than 100? {IsAny(numbers, IsLargerThan100)}");
            Console.WriteLine($"(Custom/Function) Is any number even? {IsAny(numbers, IsEven)}");

            // Utility methods for specific checks
            Console.WriteLine($"(Utility) Is any number larger than 100? {IsAnyLargerThan100(numbers)}");
            Console.WriteLine($"(Utility) Is any number even? {IsAnyEven(numbers)}");

            //example for using the Linq to filter words with more then 2 letters
            var words = new string[] { "a", "bb", "ccc", "ddd" };
            var wordsMoreThen2Letters = words.Where(x => x.Length > 2);
            Console.WriteLine(string.Join(" ", wordsMoreThen2Letters));

            //example of using extension method to count the number of lines in a string
            var sentence = @" pages-articles-multistream.xml.bz2 – Current revisions only, no talk or user pages; this is probably what you want, and is over 19 GB compressed (expands to over 86 GB when decompressed).
                pages-meta-current.xml.bz2 – Current revisions only, all pages (including talk)
                abstract.xml.gz – page abstracts
                ntity of data. Go to Latest Dumps and look out for all the files that have 'pages-meta-history' in their name.";
            Console.WriteLine(sentence.GetCountOfLines());

            //demonstrating that linq does not modify the original collection
            var number = new int[] { 1, 2, 3, 4, 5, 6, 7, 2, 1, 3 };
            var numbersWith10 = number.Append(10);
            Console.WriteLine(string.Join(" ", number));
            Console.WriteLine(string.Join(" ", numbersWith10));

            //different ways to print a string
            var name = "Arina";
            Console.WriteLine($"My name is {name}");
            Console.WriteLine("Hello World! {0}", number);
            Console.WriteLine($"Hello World! " + name);

            //using string.join example
            var greeting = new List<string> { "Hello", "World", "from", "C#" };
            Console.WriteLine(string.Join(" ", greeting));

            //simplified Linq query to filter and order odd numbers
            var orderedOddNumbersCombined = numbers.Where(x => x % 2 != 0).OrderBy(x => x);
            Console.WriteLine(string.Join(" ", orderedOddNumbersCombined));


            //Demonstrate Deferred Execution in Linq
            List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
            //Define a query using Linq
            var evenNumbers = numbers1.Where(x => x % 2 == 0);
            //Modify the source collection
            numbers1.Add(6);
            //query is executed here , when we iterate over it
            Console.WriteLine(string.Join(" ", evenNumbers));

            //Deferred execution example with strings
            var animals = new List<string>() { "cat", "dog", "elephant", "monkey", "donkey" };
            var animalStartWithD = animals.Where(x =>
            {
                Console.WriteLine("Checking Animal : " + x);
                return x.StartsWith("d");
            });

            foreach (var animal in animalStartWithD) { Console.WriteLine(animal); }

            //Method Syntax  vs  Query syntax
            var numerals = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Method Syntax
            var smallOrderMethodSyntax = numerals.Where(x => x % 2 == 0).OrderBy(x => x).Distinct();
            Console.WriteLine(string.Join(" ", smallOrderMethodSyntax));

            //Query Syntax
            var smallOrderedMethodSyntax = (from num in numerals where num % 2 == 0 orderby num select num).Distinct();
            Console.WriteLine(string.Join(" ", smallOrderedMethodSyntax));

            var numbers2 = new int[] { 1, 2, 3, 4, 50, 100, 120, 150, 200 };
            var linqResult = numbers2.Where(x => x > 100);
            Console.WriteLine(string.Join(" ", linqResult));

            var pets = new[]
            {
                new Pet(1,"Hannibal",PetType.Fish, 1.1f),
                new Pet(2,"Anthony",PetType.Cat, 2f),
                new Pet(3,"Ed", PetType.Cat, 0.7f),
                new Pet(4,"Taiga", PetType.Dog, 35f),
                new Pet(5,"Rex", PetType.Dog, 40f),
                new Pet(6,"Lucky", PetType.Dog, 5f),
                new Pet(7,"storm", PetType.Cat, 0.9f),
                new Pet(8,"neon", PetType.Cat, 2.2f),
                new Pet(9,"neon", PetType.Cat, 2.2f)
            };




            //Any Method  (The Any method in LINQ is used to determine if any elements in a sequence exist or satisfy a specified condition. It is part of the System.Linq namespace and has two overloads)
            var isAnyPetNameBruce = pets.Any(x => x.Name == "Bruce");
            Console.WriteLine(nameof(isAnyPetNameBruce) + " : " + isAnyPetNameBruce); //false

            var isAnyFish = pets.Any(x => x.PetType == PetType.Fish);
            Console.WriteLine(nameof(isAnyFish) + " : " + isAnyFish);  //true

            var specificPet = pets.Any(x => x.Name.Length > 5);
            Printer(specificPet, nameof(specificPet)); //true




            //All Method (The All method in LINQ is used to determine if all elements in a sequence satisfy a specified condition.)
            var isNameEmpty = pets.All(x => !string.IsNullOrEmpty(x.Name));
            Console.WriteLine(nameof(isNameEmpty) + " : " + isNameEmpty); //true

            var isNamesEmpty = !pets.All(x => x.Name.Length == 0);
            Console.WriteLine(nameof(isNamesEmpty) + " : " + isNamesEmpty); //true

            var areAllCats = pets.All(x => x.PetType == PetType.Cat);
            Printer(areAllCats, nameof(areAllCats)); //false

            var isCatHasWeight = pets.All(x => x.PetType == PetType.Cat && x.weight > 1);
            Printer(isCatHasWeight, nameof(isCatHasWeight)); //false

            bool ans1 = AreAllNamesValid_Refactored(words);
            Printer(ans1, nameof(ans1)); //false

            var petTypeFirst = pets.FirstOrDefault()?.PetType;
            List<Pet> PetTypeAns = pets.Where(x => x.PetType == petTypeFirst).ToList();
            Console.WriteLine(string.Join(" ", PetTypeAns));

            List<string> words1 = new List<string> { "test", "code", "abcd" };
            List<string> words2 = new List<string> { "hello", "world" };
            List<string> words3 = new List<string> { "same", "size", "four" };

            Console.WriteLine(AreAllWordsOfTheSameLength_Refactored(words1)); // True
            Console.WriteLine(AreAllWordsOfTheSameLength_Refactored(words2)); // True
            Console.WriteLine(AreAllWordsOfTheSameLength_Refactored(words3)); // True




            //Count (The Count method in LINQ is used to determine the number of elements in a sequence.)
            var CountCat = pets.Count(x => x.PetType == PetType.Cat);
            Console.WriteLine(nameof(CountCat) + " : " + CountCat);

            var PetName = pets.Count(x => x.Name == "Neon" || x.Name == "Rex");
            Console.WriteLine(nameof(PetName) + " : " + PetName);

            var PetWeight = pets.Count(x => x.weight > 10 && x.PetType == PetType.Dog);
            Console.WriteLine(nameof(PetWeight) + " : " + PetWeight);

            var CountAllPet = pets.Count();
            Console.WriteLine(nameof(CountAllPet) + " : " + CountAllPet);





            //Contains (The Contains method in LINQ is used to determine if a sequence contains a specific element.)
            var containsBruce = pets.Contains(pets.FirstOrDefault(x => x.Name == "Bruce"));
            Console.WriteLine(nameof(containsBruce) + " : " + containsBruce);

            var cats = new List<string> { "Cat", "lion", "tiger", "leopard", "jagaur" }; 

            var containsCat = cats.Contains("Cat");
            Console.WriteLine(nameof(containsCat) + " : " + containsCat);

            bool isPresentHannibal = pets.Contains(new Pet(1, "Hannibal", PetType.Fish, 1.1f)); //it created new object which is not the same object anymore
            Console.WriteLine(nameof(isPresentHannibal) + " : " + isPresentHannibal);

            //custom comparator
            bool isPresentHannibalCustomComparator = pets.Contains(new Pet(1, "Hannibal", PetType.Fish, 1.1f), new PetComparatorById()); //it created new object which is not the same object anymore
            Console.WriteLine(nameof(isPresentHannibalCustomComparator) + " : " + isPresentHannibalCustomComparator);

            var firstPetList = pets[0];
            var isPresentFirstPet = pets.Contains(firstPetList);
            Console.WriteLine(nameof(isPresentFirstPet) + " : " + isPresentFirstPet);





            //OrderBy (The OrderBy method in LINQ is used to sort a sequence of elements based on a specified key.)
            var orderByPetName = pets.OrderBy(x => x.Name);
            foreach (var pet in orderByPetName) Console.WriteLine(pet.Name);

            var orderByPetWeight = pets.OrderByDescending(x => x.weight);
            foreach (var pet in orderByPetWeight) Console.WriteLine(pet.weight);

            //thenBy after Orderby
            var thenByPetType = pets.OrderBy(x => x.PetType).ThenBy(y => y.Name);
            foreach (var pet in thenByPetType) Console.WriteLine(pet.Name + " " + pet.PetType);

            var CustomComparatorOrderBy = pets.OrderBy(x => x, new PetByTypeComparer());
            foreach (var pet in CustomComparatorOrderBy) Console.WriteLine(pet.Name + " " + pet.PetType);

            //reverse
            var reverseOrderByPetName = pets.OrderBy(x => x.Name).Reverse();
            foreach (var pet in reverseOrderByPetName) Console.WriteLine(pet.Name);




            //MinMax (The Min and Max methods in LINQ are used to determine the minimum and maximum values in a sequence.)
            var minPets = pets.Min(x => x.weight);
            Console.WriteLine(minPets);

            var maxPets = pets.Max(x => x.weight);
            Console.WriteLine(maxPets);

            var minComparablePet = pets.Min(); //obj if comparable
            Console.WriteLine(minComparablePet);

        }
    }
}





/*
//our implementation
private static bool IsAny<T>(IEnumerable<T> numbers, Func<T, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number)) // Call the predicate with the current number
        {
            return true;
        }
    }
    return false;
}


//Linq implementation
private static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
{
    if (source == null)
    {
        throw new ArgumentNullException(nameof(source));
    }
    if (predicate == null)
    {
        throw new ArgumentNullException(nameof(predicate));
    }
    foreach (var element in source)
    {
        if (predicate(element))
        {
            return true;
        }
    }
    return false;
}
*/