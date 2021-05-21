using System;
using System.Threading.Tasks;

public class SyncExp{
    public int DoSomethingAsyncBad(){
        var result = LongOperationSimulator.KeepRunningUntil(5);
        Console.Write($"Time elapsed: {result} seconds ");
        return result + 1;
    }
    
    public async Task<int> DoSomethingAsyncGood()
    {
        var beginTime = DateTime.Now;
        // since the async method return Task<T> type, we need to call Result property to get the value.
        var result =  LongOperationSimulator.KeepRunningUntilAsync(5);
        var result_2 = LongOperationSimulator.KeepRunningUntilAsync(5);

        var result1 = await result;
        var result2 = await result_2;
        
        Console.WriteLine($"Total time returned: {result1 + result2} seconds.");
        Console.WriteLine($"Time elapsed: {System.DateTime.Now.Subtract(beginTime).Seconds} seconds ");
        
        return result1 + result2;
        //return 0;

    }
}


