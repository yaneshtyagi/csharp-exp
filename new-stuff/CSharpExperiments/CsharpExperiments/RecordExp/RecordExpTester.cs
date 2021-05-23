using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CsharpExperiments.RecordExp
{

    
    public class RecordExpTester
    {
        record Animal(string Type, string Name);
        record ExoAnimal([property: JsonPropertyName("exoType")] string Type, string Name);
        public record Person (string FirstName, string LastName, string[] PhoneNumbers);
        public void Test()
        {
            Animal petAnimal = new("pet", "dog");
            Console.WriteLine(petAnimal);

            Animal wildAnimal = new("wild", "fox");
            Console.WriteLine(wildAnimal);

            ExoAnimal klingonTard = new("klingon", "tard");
            Console.WriteLine(klingonTard);
            Console.WriteLine(JsonSerializer.Serialize(klingonTard));

            // records are by default immutable. Hence following line will not compile.
            // petAnimal.Name = "cat";
            
            // Value Equality
            // Value equality means that two variables of a record type are equal
            //  if the types match and all property and field values match.
            // For other reference types, equality means identity.
            //  That is, two variables of a reference type are equal if they refer to the same object.
            ExoAnimal klingonAnimal =  new("klingon", "tard");
            Console.WriteLine($"Value Equality: {klingonTard == klingonAnimal}");

            var phoneNumbers = new string[2];
            Person person1 = new("Yanesh", "Tyagi", phoneNumbers);
            Person person2 = new("Yanesh", "Tyagi", phoneNumbers);
            
            Console.WriteLine($"Value equality check: {person1 == person2}");
            person1.PhoneNumbers[0] = "123-4567-890";
            // the below equality check will pass because Array is a reference type.
            Console.WriteLine($"Value equality check 2: {person1 == person2}");
            Console.WriteLine($"Reference equality check: {ReferenceEquals(person1, person2)}");
            
            Console.WriteLine(person1.PhoneNumbers[0] + Environment.NewLine + person2.PhoneNumbers[0]);
            person1.PhoneNumbers[0] = "123-4567-890";
            Console.WriteLine(person1.PhoneNumbers[0] + Environment.NewLine + person2.PhoneNumbers[0]);



        }
    }
}