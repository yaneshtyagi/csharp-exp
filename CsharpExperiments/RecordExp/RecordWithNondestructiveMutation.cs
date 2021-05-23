/*
 * If you need to mutate immutable properties of a record instance, you can use a with expression to achieve
 * nondestructive mutation. A with expression makes a new record instance that is a copy of an existing record instance,
 * with specified properties and fields modified.
 *
 * You use object initializer syntax to specify the values to be changed, as shown in the following example:
 */

using System;

namespace CsharpExperiments.RecordExp
{
    public class RecordWithNondestructiveMutation
    {
        //public record Person (string FirstName, string LastName, string[] PhoneNumbers);
        
        public record Person(string FirstName, string LastName)
        {
            public string[] PhoneNumbers { get; init; }
        }

        public void Test()
        {
            Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
            Console.WriteLine(person1);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

            Person person2 = person1 with { FirstName = "John" };
            Console.WriteLine(person2);
            // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { PhoneNumbers = new string[1] };
            Console.WriteLine(person2);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { };
            Console.WriteLine(person1 == person2); // output: True
        }
    }
}