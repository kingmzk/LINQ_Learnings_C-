namespace LinqTutorials
{
    public class Program
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var list = new string[]
            {
                "ARINA", "KINGMZK", "KINGMZK"
            };

            var ans =  isUpperCase(list);
            Console.WriteLine($"Are all strings uppercase? {ans}");


        }

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
        */

        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            var numbers = new[] { 1, 2, 3, 4, 99, 256, 2 };

            // Using LINQ methods directly
            bool isAnyLargerThan100 = numbers.Any(x => x > 100);
            Console.WriteLine($"Is any number larger than 100? {isAnyLargerThan100}");

            bool isAnyEven = numbers.Any(x => x % 2 == 0);
            Console.WriteLine($"Is any number even? {isAnyEven}");

            // Using lambda expressions directly with the IsAny method
            Console.WriteLine(IsAny(numbers, x => x > 100));
            Console.WriteLine(IsAny(numbers, x => x % 2 == 0));

            // Using predefined predicate functions with the IsAny method
            Console.WriteLine(IsAny(numbers, IsLargerThan100));
            Console.WriteLine(IsAny(numbers, IsEven));

            // Using the utility methods for specific checks
            Console.WriteLine($"(Custom method) Is any number larger than 100? {IsAnyLargerThan100(numbers)}");
            Console.WriteLine($"(Custom method) Is any number even? {IsAnyEven(numbers)}");

            Console.ReadKey();
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
    }
}