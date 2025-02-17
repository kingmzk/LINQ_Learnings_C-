using LinqTutorials.Comparator;
using LinqTutorials.Models;
using System.Linq;

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





            //Average (The Average method in LINQ is used to calculate the average value of a sequence of elements.)
            var Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var averagePets = pets.Average(x => x.weight);
            Console.WriteLine(averagePets);

            var average = Numbers.Average();
            Console.WriteLine(average);




            //Sum (The Sum method in LINQ is used to calculate the sum of a sequence of elements.)
            var sumPets = pets.Sum(x => x.weight);
            Console.WriteLine(sumPets);

            var sum = Numbers.Sum();
            Console.WriteLine(sum);




            //ElementAt (The ElementAt method in LINQ is used to retrieve a specific element from a sequence.)
            var firstPet = pets.ElementAt(0);
            Console.WriteLine(firstPet.Name);

            IEnumerable<int> IenumerableNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var elementAtIndex1 = IenumerableNumbers.ElementAt(1);
            Console.WriteLine($"{elementAtIndex1} is element At Index 1");

            //var nonExistElement = IenumerableNumbers.ElementAt(100); //throws exception

            var nonExistElementDefault = IenumerableNumbers.ElementAtOrDefault(100); //returns default value
            Console.WriteLine($"{nonExistElementDefault} is element At Index 100");





            //First || Last (The First and Last methods in LINQ are used to retrieve the first or last element from a sequence.)
            var firstPetFirst = pets.First();
            Console.WriteLine(firstPetFirst.Name);

            var PetLast = pets.Last();
            Console.WriteLine(PetLast.Name);

            var firstNumber = IenumerableNumbers.First();
            Console.WriteLine($"{firstNumber} is first number");

            var firstNumberDefault = IenumerableNumbers.FirstOrDefault();
            Console.WriteLine($"{firstNumberDefault} is first number Or Default");

            var lastNumberDefault = IenumerableNumbers.Last();
            Console.WriteLine($"{lastNumberDefault} is last number Or Default");

            var heaviestPet = pets.OrderByDescending(x => x.weight).FirstOrDefault();
            Console.WriteLine($"{heaviestPet.Name} is heaviest pet");





            //Single 0r SingleOrDefault (The Single and SingleOrDefault methods in LINQ are used to retrieve a single element from a sequence.)

            //var singleElement = IenumerableNumbers.Single(); //throws exception
            //var singleElementDefault = IenumerableNumbers.SingleOrDefault(); //returns default value

            var singlePet = pets.Single(x => x.Id == 1);
            Console.WriteLine($"{singlePet.Name} is single pet");

            var singlePetDefault = pets.SingleOrDefault(x => x.Id == 100);
            Console.WriteLine($"{singlePetDefault} is single pet Or Default");





            //Where (The Where method in LINQ is used to filter a sequence of elements based on a predicate.)
            var catss = pets.Where(x => x.PetType == PetType.Cat);
            foreach (var pet in catss) Console.WriteLine($"{pet.Name} is cat");

            var Catss1AndWeightMoreThen1 = pets.Where(x => x.PetType == PetType.Cat && x.weight > 1);
            foreach (var pet in Catss1AndWeightMoreThen1) Console.WriteLine($"{pet.Name} is cat and Weight more then 1");

            var evenNumberss = IenumerableNumbers.Where(x => x % 2 == 0);
            foreach (var numberss in evenNumberss) Console.WriteLine($"{numberss} is even number");


            //select (The Select method in LINQ is used to transform a sequence of elements into a new sequence of elements.)
            var namess = pets.Select(x => x.Name);
            foreach (var nam in namess) Console.WriteLine($"{nam} is name");   

            var cats2 = pets.Where(x => x.PetType == PetType.Cat).Select(x => x.Name);
            foreach (var pet2 in cats2) Console.WriteLine($"{pet2} is cat");

            //contains with where (The Contains method in LINQ is used to check if a sequence contains a specific element.)
            var containsCats = pets.Contains(pets.Where(x => x.PetType == PetType.Cat).FirstOrDefault());
            Console.WriteLine($"{containsCats} is contains cat");

            var cat3 = pets.Where(x => x.Name.Contains("a"));
            foreach (var pet3 in cat3) Console.WriteLine($"{pet3.Name} is cat");  





            // Take  (The Take method in LINQ is used to take a specific number of elements from a sequence.)
            var first3Numbers = numbers.Take(3);
            foreach (var num in first3Numbers) Console.WriteLine($"{num} is first 3 numbers");

            var last3Numbers = numbers.TakeLast(3);
            foreach (var num in last3Numbers) Console.WriteLine($"{num} is last 3 numbers");

            var threeHeaviestPets = pets.OrderBy(x => x.weight).TakeLast(3);
            foreach (var pet in threeHeaviestPets) Console.WriteLine($"{pet.Name} is heaviest pet of weight {pet.weight}");

            var secondLargestNumber = numbers.OrderBy(x => x).TakeLast(2).First();
            Console.WriteLine($"{secondLargestNumber} is second largest number");

            var secondLargestSKipNumber = numbers.OrderByDescending(x => x).Skip(1).First();
            Console.WriteLine ($"{secondLargestSKipNumber} is second largest number");

            var sixtyPercentOfPets = pets.Take((int) (pets.Count() * 0.6));
            foreach (var pet in sixtyPercentOfPets) Console.WriteLine($"{pet.Name} is 60% of pets");

            //Take While commonly used with Ordered collection
            var ArrayNum = new int[] { 1, 2, 3, 5, 10, 150, 200, 99, 15, 12 };
            var numLessThen20 = ArrayNum.TakeWhile(x => x < 20);
            foreach (var n in numLessThen20) Console.WriteLine($"{n} is less then 20");

            var PetSWeightLessThen20 = pets.TakeWhile(x => x.weight < 20);
            foreach (var pet in PetSWeightLessThen20) Console.WriteLine($"{pet.Name} is weight less then 20");




            //Skip (The Skip method in LINQ is used to skip a specific number of elements from a sequence.)
            var skip3Numbers = numbers.Skip(3);
            foreach (var num in skip3Numbers) Console.WriteLine($"{num} is skip 3 numbers");

            var skipLast3Numbers = numbers.SkipLast(3);
            foreach (var num in skipLast3Numbers) Console.WriteLine($"{num} is skip last 3 numbers");

            var usingTake = numbers.Take(numbers.Count() - 3);
            foreach (var num in usingTake) Console.WriteLine($"{num} is using take");

            var halfSkipFromStart = numbers.Skip(numbers.Count() / 2);
            foreach (var num in halfSkipFromStart) Console.WriteLine($"{num} is half skip from start");

            var secondPageOfPets = pets.Skip(2).Take(2);
            foreach (var pet in secondPageOfPets) Console.WriteLine($"{pet.Name} is second page of pets");

            var skipWhile = ArrayNum.SkipWhile(x => x < 20);
            foreach (var num in skipWhile) Console.WriteLine($"{num} is skip while");

            var skipWhileHeavireThen30 = pets.SkipWhile(x => x.weight < 20);
            foreach (var pet in skipWhileHeavireThen30) Console.WriteLine($"{pet.Name} is skip while heavire then 20");

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