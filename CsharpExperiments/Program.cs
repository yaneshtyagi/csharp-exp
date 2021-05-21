using System;
using System.Threading.Tasks;

namespace CsharpExperiments
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await new SyncExp().DoSomethingAsyncGood();
            Console.Write("...done");
        }
    }
}
