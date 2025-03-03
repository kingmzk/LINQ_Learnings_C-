using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
                new Pet(6,"Lucky", PetType.Dog, 5f),
                new Pet(7,"storm", PetType.Cat, 0.9f),
                new Pet(8,"neon", PetType.Cat, 2.2f),
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






            //SelectMany (The SelectMany method in LINQ is used to flatten a sequence of sequences into a single sequence.)
            List<string> sentences = new List<string>
            {
                "Hello world",
                "LINQ is powerful",
                "C# is great"
            };

            var wordss = sentences.SelectMany(sentence => sentence.Split(' '));

            foreach (var word in wordss)
            {
                Console.WriteLine(word);
            }

            List<Persons> people = new List<Persons>
            {
                new Persons { Name = "Alice", Pets = new List<string> { "Dog", "Cat" } },
                new Persons { Name = "Bob", Pets = new List<string> { "Parrot" } },
                new Persons { Name = "Charlie", Pets = new List<string> { "Fish", "Hamster" } }
            };

            var allPets = people.SelectMany(person => person.Pets);

            foreach (var pet in allPets)
            {
                Console.WriteLine(pet);
            }
            //without linq
            var numberss0 = new[] { 1, 2, 3 };
            var letters0 = new[] { "A", "B" };
            var results0 = new List<string>();

            for (int i = 0; i < numberss0.Length; i++)
            {
                for (int j = 0; j < letters0.Length; j++)
                {
                    results0.Add($"{numberss0[i]}{letters0[j]}");
                }
            }
               foreach (var item in results0) Console.WriteLine(item);


            //with linq
            var numbers0 = new[] { 1, 2, 3 };
            var letters = new[] { "A", "B" };

            var result0 = numbers0.SelectMany(num => letters, (num, letter) => $"{num}{letter}");

            foreach (var item in result0) Console.WriteLine(item);





            //Generating New Collections (The Generate method in LINQ is used to generate a sequence of elements. And also we can change types of elements)
            var emptyInts = Enumerable.Empty<int>();    //emptyInts
            Console.WriteLine($"{string.Join(",", emptyInts)}");

            var tenCopyOf100 = Enumerable.Repeat(100, 10);
            Console.WriteLine($"{string.Join(",", tenCopyOf100)}");

            var oneToTen = Enumerable.Range(1, 10);
            Console.WriteLine($"{string.Join(",", oneToTen)}");

            var powerOfTwo = Enumerable.Range(1,10).Select(x => Math.Pow(x, 2));
            Console.WriteLine($"{string.Join(",", powerOfTwo)}");

            var lettersss = Enumerable.Range('A',10).Select(x => (char) x);
            Console.WriteLine($"{string.Join(",", lettersss)}");

            var nonEmptyNumbers = new int[] { 1, 2, 3, 4, 5, };
            var defaultIfEmpty = Enumerable.DefaultIfEmpty(nonEmptyNumbers);
            Console.WriteLine($"{string.Join(",", defaultIfEmpty)}");

            var emptyNumbers = Enumerable.Empty<int>();
            var defaultIfEmpty1 = Enumerable.DefaultIfEmpty(emptyNumbers);
            var defaultIfEmpty2 = Enumerable.Empty<int>().DefaultIfEmpty(10);
            Console.WriteLine($"{string.Join(",", defaultIfEmpty2)}");




            //GroupBy (The GroupBy method in LINQ is used to group elements in a sequence based on a specified key. And also we can change types of elements)
            var petsWeightsByTypeLookUp = pets.ToLookup(pet => pet.PetType, pet => pet.weight);
            foreach(var item in petsWeightsByTypeLookUp) Console.WriteLine($"{item.Key} : {string.Join(",", item)}");

            var sumOfWeightPerType = petsWeightsByTypeLookUp.ToDictionary(lookUp => lookUp.Key, lookUp => lookUp.Sum());
            foreach (var item in sumOfWeightPerType) Console.WriteLine($"{item.Key} : {item.Value}");

            var grouping = pets.GroupBy(Pet => Pet.PetType, Pet => Pet.weight);
            foreach (var item in grouping) Console.WriteLine($"{item.Key} : {string.Join(",", item)}");

            var sumOfWeightPerTypes = grouping.ToDictionary(lookUp => lookUp.Key, lookUp => lookUp.Sum());
            foreach (var item in sumOfWeightPerTypes) Console.WriteLine($"{item.Key} : {item.Value}");

            var grouping1 = pets.GroupBy(Pet => Pet.PetType, Pet => Pet.weight, (key, group) => new { PetType = key, Weight = group.Sum()});
            foreach (var item in grouping1) Console.WriteLine($"{item.PetType} : {item.Weight} kg");

            var groupByWeight = pets.GroupBy(pet => Math.Floor(pet.weight),
                (key, pets) => new { WeightFloor = key, MinWeight = pets.Min(pet => pet.weight), MaxWeight = pets.Max(pet => pet.weight) })
                .OrderBy(groupInfo => groupInfo.WeightFloor)
                .Select(groupInfo => $"{groupInfo.WeightFloor} : {groupInfo.MinWeight} - {groupInfo.MaxWeight}");

            foreach (var item in groupByWeight) Console.WriteLine(item);




            //Intersect & Except (The Intersect method in LINQ is used to find the common elements between two sequences. And also we can change types of elements)
            var listNumbers1 = new int[] { 1, 2, 3, 4, 5 };
            var listNumbers2 = new int[] { 4, 5, 6, 7, 8 };

            var intersecList = listNumbers1.Intersect(listNumbers2);
            var exceptList = listNumbers1.Except(listNumbers2);

            Console.WriteLine($"{string.Join(",", intersecList)}");
            Console.WriteLine($"{string.Join(",", exceptList)}");

            var  bothListExcludeCommon = listNumbers1.Except(listNumbers2).Concat(listNumbers2.Except(listNumbers1));
            var bothListEqual = listNumbers1.SequenceEqual(listNumbers2);
            var bothListEqualCorrected = listNumbers1.Concat(listNumbers2).Except(listNumbers1.Intersect(listNumbers2)).OrderBy(x => x);


            Console.WriteLine($"{string.Join(",", bothListExcludeCommon)}");
            Console.WriteLine(bothListEqual);
            Console.WriteLine(string.Join(",", bothListEqualCorrected));

            List<string> words1 = new List<string> { "apple", "banana", "cherry" };
            List<string> words2 = new List<string> { "banana", "cherry", "date" };

            int commonCount = words1.Select(x => x.ToUpper()
            ).Intersect(words2.Select(x => x.ToUpper())).Count();
            Console.WriteLine($" Number of common words: {commonCount}");






            //Joins (The Join method in LINQ is used to join two sequences based on a specified key. And also we can change types of elements)
            var join1List = new List<int> { 1, 2, 3, 4, 5 };
            var join2List = new List<int> { 4, 5, 6, 7, 8 };

            var innerJoin = join1List.Join(join2List, x => x, y => y, (x, y) => x);

            var pets1 = new List<Pet>
            {
                new Pet (1, "Hannibal", PetType.Fish, 1.1f),
                new Pet (2, "Anthony" , PetType.Cat, 2f),
                new Pet (3, "Tom", PetType.Dog, 3.1f),
                new Pet (4, "Hannibal", PetType.Dog, 4.1f)
            };

            var clinicAppointments = new[]
            {
                new ClinicAppointments (clinicId : 2, petId:1, appointmentDate : new DateTime(2021, 10, 15)),
                new ClinicAppointments (clinicId : 1, petId:1, appointmentDate : new DateTime(2021, 3, 22)),
                new ClinicAppointments (clinicId : 2, petId:2, appointmentDate : new DateTime(2021, 6, 15)),
                new ClinicAppointments (clinicId : 3, petId:4, appointmentDate : new DateTime(2021, 9, 5))
            };

            var veterinaryClinic = new[]
            {
                new VeterinaryClinic(id : 1, name: "Happy Paws Clinic"),
                new VeterinaryClinic(id : 2, name: "Fish Clinic"),
                new VeterinaryClinic(id : 3, name: "Cat Clinic")
            };

            var petsAppointmentDate = pets1.Join(clinicAppointments,
                pet => pet.Id, clinicAppointments => clinicAppointments.PetId, 
                (pet, clinicAppointments) => $"{pet.Name} has an appointement at : {clinicAppointments.AppointmentDate}");
            foreach (var item in petsAppointmentDate) Console.WriteLine(item);

            var petsAppointmentDataWithClient = pets1.Join(clinicAppointments,
                pet => pet.Id, clinicAppointments => clinicAppointments.PetId,
                (pet, clinicAppointments) => new
                {
                    Pet = pet,
                    Appointments = clinicAppointments
                }).Join(veterinaryClinic,
                petAndAppointments => petAndAppointments.Appointments.ClinicId,
                veterinaryClinic => veterinaryClinic.Id,
                (petAndAppointments, veterinaryClinic) => $"{petAndAppointments.Pet.Name} has an appointement at : {petAndAppointments.Appointments.AppointmentDate} at {veterinaryClinic.Name}");

            foreach (var item in petsAppointmentDataWithClient) Console.WriteLine($"{item} is pets appointment data with client");

            var petsAppointmentDates = pets1.Join(clinicAppointments,  //Group Join      //key= {value,value,value }  while join = key=value,key=value,key=value
              pet => pet.Id, clinicAppointments => clinicAppointments.PetId,
              (pet, clinicAppointments) => $"{pet.Name} has an appointement at : {clinicAppointments.AppointmentDate}");
            foreach (var item in petsAppointmentDates) Console.WriteLine(item);


            var leftJoinUsingGroupJoin = pets1.GroupJoin(clinicAppointments,
                pet => pet.Id,
                clinicAppointments => clinicAppointments.PetId,
                (pet, appointment) => new
                {
                    Pet = pet,
                    Appointments = appointment.DefaultIfEmpty()
                }).SelectMany(
                petAppointmentsPair => petAppointmentsPair.Appointments,
                (petAppointmentsPair, singleAppointment) => $"Pet {petAppointmentsPair.Pet.Name} has an appointement at {singleAppointment?.AppointmentDate}"
                );

            foreach (var item in leftJoinUsingGroupJoin) Console.WriteLine(item);




            //Aggregates(The Aggregate method in LINQ is used to combine a sequence of elements into a single value.)
            var nums = new int[] { 10, 1, 4, 17, 122 };
            var AggreateSum = nums.Aggregate((sum,nextNums) => sum + nextNums);
            Console.WriteLine(AggreateSum);

            var sentence = "The quick brown fox jumps over the lazy dog.";
            var longestWord = sentence.Split(" ").Aggregate((longestSoFar, nextWord) => nextWord.Length > longestSoFar.Length ? nextWord : longestSoFar);
            Console.WriteLine(longestWord);

            var lettrs = new[] {"a","b","c","d","e","f","g","h","i","j","k","l","m"};   
            var lettersJoin = lettrs.Aggregate((resultsSoFar,nextLetter) => $"{resultsSoFar},{nextLetter}");
            Console.WriteLine(lettersJoin);

            var CountLetters = lettrs.Aggregate (0,(letter, nextLetter) => (int) letter + 1);
            Console.WriteLine(CountLetters);

            int factorialBase = 10;
            var factorial = Enumerable.Range(1, factorialBase - 1).Aggregate(10, (factorialSoFar, nextNum) => factorialSoFar * (factorialBase - nextNum));
            Console.WriteLine(factorial);




            //Zip (The Zip method in LINQ is used to combine two sequences into a single sequence of tuples.)
            int[] newNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // (if length of two arrays are not same then it will eliminate the values of the longer array)
            string[] strings = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            
            var zip_merge_numbers_and_strings = newNumbers.Zip(strings, (first, second) => $"{first} - {second}");
            foreach (var item in zip_merge_numbers_and_strings) Console.WriteLine(item);

            var countries = new string[] { "France", "Germany", "Italy", "Spain", "United States" , "United Kingdom" ,"India"};
            var currencies = new string[] { "EUR", "EUR", "EUR", "EUR", "USD", "GBP", "INR"};

            var countriesCurrencyDictionary = countries.Zip(currencies).ToDictionary(tuple => tuple.First, tuple => tuple.Second);
            foreach (var item in countriesCurrencyDictionary) Console.WriteLine($"{item.Key} - {item.Value}");

            var years = new List<int> { 2023, 2022, 2021 };
            var months = new List<int> { 12, 5, 8 };
            var days = new List<int> { 25, 15, 10 };

            // Calling the function
            var dates = BuildDates(years, months, days);

            // Printing results
            Console.WriteLine("Generated dates in order:");
            foreach (var date in dates)
            {
                Console.WriteLine(date.ToString("yyyy-MM-dd"));
            }





            // Query Syntax OverView (The query syntax in LINQ is a way to write LINQ queries using a declarative syntax)
            var nummber = new int[] { 9, 3, 7, 1, 2 };
            var orderedNumms = from nummbers in nummber         // starts with from
                               orderby nummbers                 // we can use let and other methods like orderBy,GroupBy,Where,Join
                               select nummbers * 2;                 // ends with select, group by

            var orderedNummss = from nummbers in nummber 
                                let floorOfSquare = Math.Floor(Math.Sqrt(nummbers))
                                orderby floorOfSquare
                                select floorOfSquare;                 


            foreach (var num in orderedNummss) Console.WriteLine(num);
            foreach (var num in orderedNumms) Console.WriteLine(num);




            //OrderBy (The OrderBy method in LINQ is used to sort a sequence of elements based on a specified key.)
            var orderNummsDesc = from nummbers in nummber
                                 orderby nummbers descending
                                 select nummbers;
            foreach (var num in orderNummsDesc) Console.WriteLine(num);

            var petsOrderPetsDesc = from pet in pets
                                    orderby pet.Name descending
                                    select pet;
            foreach (var num in petsOrderPetsDesc) Console.WriteLine(num.Name);

            var petsOrderPetsTypeThenIdDesc = from pet in pets
                                              orderby pet.PetType, pet.Id 
                                              select pet;
            foreach (var num in petsOrderPetsTypeThenIdDesc) Console.WriteLine($"{num.Name} - {num.Id} - {num.PetType}");

            var petsOrderByNameDesc2 = (from pet in pets
                                        orderby pet.Name
                                        select pet).Reverse();      //There is No Reverse in this query syntax so combine
            foreach (var num in petsOrderByNameDesc2) Console.WriteLine(num.Name);



            //Where (The Where method in LINQ is used to filter a sequence based on a predicate.)
            var evenNumbers = from nummbers in nummber
                              where nummbers % 2 == 0
                              select nummbers;
            foreach (var num in evenNumbers) Console.WriteLine(num);

            var orderedevenNumbers = from nummbers in nummber
                              where nummbers % 2 == 0
                              select nummbers;
            foreach (var num in orderedevenNumbers) Console.WriteLine($"{num} is even");

            var specificPets = from pet in  pets
                               where pet.PetType == PetType.Cat ||
                               pet.PetType == PetType.Dog && pet.weight < 10 && pet.Name.Length < 5
                               select pet;
            foreach (var num in specificPets) Console.WriteLine($"{num.Name} - {num.PetType} - {num.weight}");

            var countOfCats = (from pet in pets where pet.PetType==PetType.Cat select pet).Count(); //Count method is not there in query syntax
            Console.WriteLine($"{countOfCats} is count of cats");




            //Select (The Select method in LINQ is used to transform a sequence of elements into a new sequence of elements.)
            var numb = new[] { 1, 2, 3, 4, 5 };
            var tripledNumbers = from num in numb
                                 select num * 3;
            foreach (var num in tripledNumbers) Console.WriteLine(num);

            var selectString = new[] {"one", "two", "three", "four", "five"};
            var upperCaseString = from str in selectString 
                                  select str.ToUpper();
            foreach (var num in upperCaseString) Console.WriteLine(num);

            var selectPet = from pet in pets 
                            select pet.Name;
            foreach (var num in selectPet) Console.WriteLine(num);

            var heavyPetTypes = (from pet in pets
                                where pet.weight > 10
                                select pet.PetType).Distinct();  //Distinct method is not there in query syntax
            foreach (var num in heavyPetTypes) Console.WriteLine(num);




            //SelectMany (The SelectMany method in LINQ is used to flatten a sequence of sequences into a single sequence.)
            var nestedListOfNumbers = new List<List<int>>
            {
                new List<int> { 1, 2, 3},
                new List<int> { 4, 5, 6},
                new List<int> { 7, 8, 9}
            };
            var allNumbers  = from lisst in nestedListOfNumbers
                              from number in lisst
                              select number;
            foreach (var num in allNumbers) Console.WriteLine(num);

            var petsOfPeople = from person in people
                               where person.Name.StartsWith('J')
                               from pet in person.Pets
                               select pet;

            foreach (var pet in petsOfPeople) Console.WriteLine(pet);

            var numbeers = new[] { 1, 2, 3 };
            var lettters = new[] {'A','B','C'};

            var ressultts = new List<string>();
            foreach (var num in numbeers)
            {
                foreach (var lett in lettters)
                {
                    ressultts.Add($"{num} {lett}");
                }
            }
            Console.WriteLine(string.Join(" ", ressultts));

            var querySyntaxResult = from num in numbeers
                                    from lett in lettters
                                    select $"{num} , {lett}";
            foreach (var item in querySyntaxResult) Console.WriteLine(item);



            //GroupBy(The GroupBy method in LINQ is used to group a sequence of elements into a collection of groups.)
            var groupPets = from pet in pets
                            group pet by pet.PetType;

            foreach (var pet in groupPets) Console.WriteLine($"{pet.Key} - {pet.Count()}");

            var petTypeWeightSums = groupPets.ToDictionary(
                grouping => grouping.Key,
                grouping => grouping.Sum(pet => pet.weight));
                foreach (var pet in petTypeWeightSums) Console.WriteLine($"{pet.Key} - {pet.Value}");

            var petWeightGroups = from pet in pets
                                  group pet by Math.Floor(pet.weight) into petGrouping
                                  orderby petGrouping.Key
                                  let petsOrderByWeight = from pet in petGrouping orderby pet.weight select pet
                                  select new
                                  {
                                      Key = petGrouping.Key,
                                      LightestPet = petsOrderByWeight.First(), // storing in variable
                                      HeaviestPet = petsOrderByWeight.Last()
                                  };

            var petsWeightsGroupsAsStrings = petWeightGroups
                .Select(petWeightGroup => $"{petWeightGroup.Key} - {petWeightGroup.LightestPet.Name} - {petWeightGroup.HeaviestPet.Name}");

            foreach (var pet in petsWeightsGroupsAsStrings) Console.WriteLine(pet);




            //Join
            var queryInnerJoin = from pet in pets
                            join appointment in clinicAppointments
                            on pet.Id equals appointment.PetId
                            select $"{pet.Name} - {appointment.AppointmentDate}";
            Console.WriteLine(string.Join(" ", queryInnerJoin));

            var queryLeftJoin = from pet in pets
                                join appointment in clinicAppointments
                                on pet.Id equals appointment.PetId into petAppointments
                                from singleAppointment in petAppointments.DefaultIfEmpty()
                                select $"Pet Name : {pet.Name} - Appointment Date: {singleAppointment?.AppointmentDate}";
             Console.WriteLine(string.Join(" ", queryLeftJoin));




            //Improvements After DotNet 6
            var heaviestPetBefore6 = pets.OrderBy(x => x.weight).Last();
            var heaveiestPetAfter6 = pets.MaxBy(x => x.weight);    //MaxBy (The MaxBy method in LINQ is used to retrieve the element with the maximum value in a sequence.)
            Console.WriteLine(heaveiestPetAfter6.Name);
            var petWithShortestName = pets.MinBy(x => x.Name.Length); Console.WriteLine(petWithShortestName.Name);

            //DistinctBy (The DistinctBy method in LINQ is used to retrieve distinct elements from a sequence based on a specified key selector.)
            var distinctPets = pets.DistinctBy(x => x.PetType);
            foreach (var pet in distinctPets) Console.WriteLine($"{pet.Name} - {pet.PetType}");

            //chunk (The Chunk method in LINQ is used to split a sequence into chunks of a specified size.)
            var numbersChunk = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var chunks = numbersChunk.Chunk(3);
            foreach (var chunk in chunks) Console.WriteLine(string.Join(" ", chunk));

            //Zip can accept 3 parameters to join
            var yearss = new int[] { 1998, 2000, 2001, 1999 };
            var monthss = new int[] { 6, 8, 10, 2 };
            var dayss = new int[] { 10, 6, 3, 2, };

            var datess = years.Zip(months, days)
                .Select(yearMonthDay => $"{yearMonthDay.First} - {yearMonthDay.Second} - {yearMonthDay.Third}");
            foreach (var date in datess) Console.WriteLine(date);


            // ^ ( it fetches elements from last )
            var thirdFromEnd = numbersChunk.ElementAt(numbersChunk.Count() - 3);
            var thirdFromEndNew = numbersChunk.ElementAt(^3);
            Console.WriteLine(thirdFromEnd);
            Console.WriteLine(thirdFromEndNew);

            //.. (Get elements inBetween indexes)
            var twoToSix = numbersChunk.Skip(2).Take(4);
            var twoToSixNew = numbersChunk.Take(2..6);
            foreach (var num in twoToSix) Console.WriteLine(num);
            foreach (var num in twoToSixNew) Console.WriteLine(num);

            var allAfter6 = numbersChunk.Take(6..); 
            var allBefore6 = numbersChunk.Take(..6);
            foreach (var num in allAfter6) Console.WriteLine(num);
            foreach (var num in allBefore6) Console.WriteLine(num);

            var leaveLast3 = numbersChunk.Take(..^3);
            var leaveFirst3 = numbersChunk.Take(3..);
            foreach (var num in leaveLast3) Console.WriteLine(num);
            foreach (var num in leaveFirst3) Console.WriteLine(num);

            //TryGetNonEnumnertedCount (The TryGetNonEnumeratedCount method in LINQ is used to get the number of elements in a sequence that are not enumerated.)
            var petsCount = pets.TryGetNonEnumeratedCount(out int count);
            Console.WriteLine(count);
            Console.WriteLine(petsCount);


        }


        public static IEnumerable<DateTime> BuildDates(
          IEnumerable<int> years,
          IEnumerable<int> months,
          IEnumerable<int> days)
        {
            // Zip years and months into pairs
            var yearMonthPairs = years.Zip(months, (year, month) => new { year, month });

            // Zip pairs with days and create DateTime objects, then order by date
            return yearMonthPairs.Zip(days,
                (yearMonth, day) => new DateTime(yearMonth.year, yearMonth.month, day))
                .OrderBy(date => date);
        }


    }


    class VerySpecificList<T> : List<T>
    {
        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            throw new InvalidOperationException("We dont support filtering here");
        }
    }

}
