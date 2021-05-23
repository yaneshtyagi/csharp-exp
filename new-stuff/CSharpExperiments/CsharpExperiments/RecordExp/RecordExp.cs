/*
 * Ref: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types
 * Learnings:
 * 1. Record vs Structures - record support inheritance while structures do not. Also, structs are value type while record is reference type.
 */


namespace CsharpExperiments.RecordExp_old
{
    public class RecordExp
    {
        // Person record in immutable. This is the default behavior of following syntax.
        public record Person(string FirstName, string LastName);

        // Person record is immutable. Notice the init property.
        public record Person1
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
        };

        // Person record in mutable.
        public record Person3
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        };

    }


}

