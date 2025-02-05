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
                new Pet(8,"neon", PetType.Cat, 2.2f)
            };

            //Any Method
            var isAnyPetNameBruce = pets.Any(x => x.Name == "Bruce");
            Console.WriteLine(nameof(isAnyPetNameBruce) + " : " + isAnyPetNameBruce);

            var isAnyFish = pets.Any(x => x.PetType == PetType.Fish);
            Console.WriteLine(nameof(isAnyFish) + " : " + isAnyFish);

            var specificPet = pets.Any(x => x.Name.Length > 5);
            Printer(specificPet, nameof(specificPet));


            //All Method
            var isNameEmpty = pets.All(x => !string.IsNullOrEmpty(x.Name));
            Console.WriteLine(nameof(isNameEmpty) + " : " + isNameEmpty);

            var isNamesEmpty = !pets.All(x => x.Name.Length == 0);
            Console.WriteLine(nameof(isNamesEmpty) + " : " + isNamesEmpty);

            var areAllCats = pets.All(x => x.PetType == PetType.Cat);
            Printer(areAllCats, nameof(areAllCats));

            var isCatHasWeight = pets.All(x => x.PetType == PetType.Cat && x.weight > 1);
            Printer(isCatHasWeight, nameof(isCatHasWeight));

            bool ans1 = AreAllNamesValid_Refactored(words);
            Printer(ans1, nameof(ans1));

            var petTypeFirst = pets.FirstOrDefault().PetType;
            List<Pet> PetTypeAns = pets.Where(x => x.PetType == petTypeFirst).ToList();
            Console.WriteLine(string.Join(" ", PetTypeAns));

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