using System;
using System.Threading.Tasks;
using CsharpExperiments.RecordExp;

namespace CsharpExperiments
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //await new SyncExp().DoSomethingAsyncGood();
            // await new SyncExp().DoSomethingAsyncVoidGood();
            new RecordExpTester().Test();
            Console.Write("...done");
        }
    }
}
