// See https://aka.ms/new-console-template for more information

using CSharp8;

Console.WriteLine("Hello, World!");

var testInterface = new TestInterface();
Console.WriteLine(testInterface.UnimplementedMethod());

IInterfaceWithMethodImplementation ti2 = new TestInterface();
Console.WriteLine(ti2.CanIImplementMethod());
Console.WriteLine(testInterface.AnotherImplementedMethod());
Console.WriteLine(ti2.AnotherImplementedMethod());