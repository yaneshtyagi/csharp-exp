using System;
using System.Threading.Tasks.Dataflow;

char l = '%';
Console.WriteLine($"Is '{l}' a letter? {IsLetter(l)}");
bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

// match an expression against a pattern
static bool IsFirstSummerMonday(DateTime date) => date is { Month: 6, Day: <=7, DayOfWeek: DayOfWeek.Monday };

Console.WriteLine(IsFirstSummerMonday(DateTime.Now));

// is operator can also be used to check run time type of an expression:
int i = 5;
object iBoxed = i;
int? jNullable = 3;
if (iBoxed is int a && jNullable is int b) //jNullable is int b defines a new variable b.
{
    Console.WriteLine(a + b);  // output 8
}

// is is used to check for null
string? nameNullable = "null";

if (nameNullable is null)
{
    Console.WriteLine("Hello Noname");
}

// C# 9.0 support is not

if (nameNullable is not null)
{
    Console.WriteLine("Hello " + nameNullable);
}

// switch expression (C# 8.0)
Point p = Transform(new Point(100, 200));
Console.WriteLine($"Point is: {p.X},{p.Y}");

Point Transform(Point point) => point switch
{
    { X: 0, Y: 0 }                          => new Point(0, 0),
    { X: var x, Y: var y } when x < y => new Point(x + y, y),
    { X: var x, Y: var y } when x > y => new Point(x - y, y),
    { X: var x, Y: var y }            => new Point(2 * x, 2 * y),
};
public readonly struct Point
{
    public Point(int x, int y) => (X, Y) = (x, y);
    public int X { get; }
    public int Y { get; }
}


