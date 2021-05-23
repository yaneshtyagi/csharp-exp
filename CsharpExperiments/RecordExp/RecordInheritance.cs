using System;

namespace CsharpExperiments.RecordExp
{
    public class RecordInheritance
    {
        public abstract record Person(string FirstName, string LastName);
        
        public record Teacher(string FirstName, string LastName, int Grade)
            : Person(FirstName, LastName);

        public record Student(string FirstName, string LastName, int Grade)
            : Person(FirstName, LastName);
        
        public static void InheritanceTest()
        {
            var teacher = new Teacher("Yanesh", "Tyagi", 5);
            Console.WriteLine(teacher);
            // output: Teacher { FirstName = Yanesh, LastName = Tyagi, Grade = 5 }
        }

        /*
         * For two record variables to be equal, the run-time type must be equal.
         * In the below example, although teacher and student are derived from Person type,
         *  at runtime they are Teacher and Student types respectively and hence are not equal.
         */
        public static void EqualityTest()
        {
            var teacher = new Teacher("Yanesh", "Tyagi", 5);
            var student = new Student("Yanesh", "Tyagi", 5);
            
            Console.WriteLine(teacher == student); // output: False

            Student student2 = new Student("Nancy", "Davolio", 3);
            Console.WriteLine(student2 == student); // output: True
        }
        
    }
}