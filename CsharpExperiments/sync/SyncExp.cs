/* LEARNINGS:
 * 1. If all tasks in the pipeline are not async, the whole pipeline becomes synchronous.
 * 2. Call to an async method without await will make the pipeline  synchronous.
 * 3. Thread.sleep is sync. Use Task.Delay() for async.
 * 4. Tasks needs to be assigned to the respective task variables. The execution begins at the time of assignment.
 * 5, Prefer Task.FromResult over Task.Run for pre-computed or trivially computed data
 * 
 */
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
        
        var longTask1 =  LongOperationSimulator.KeepRunningUntilAsync(5); //task execution begins
        var longTask2 = LongOperationSimulator.KeepRunningUntilAsync(5); // task execution begins

        // I can use only one await statement for all tasks using WhenALl method. This makes the code cleaner to read.
        await Task.WhenAll(longTask1, longTask2);

        // since the async method return Task<T> type, we need to call Result property to get the value.
        var timeReturnedByFirstTask = longTask1.Result;
        var timeReturnedBySecondTask = longTask2.Result;
        var totalTimeReturnedByAllTasks = timeReturnedByFirstTask + timeReturnedBySecondTask;
        var timeElapsed = System.DateTime.Now.Subtract(beginTime).Seconds;
        
        Console.WriteLine($"Total time returned by all tasks: {totalTimeReturnedByAllTasks} seconds.");
        Console.WriteLine($"Time elapsed: {timeElapsed} seconds ");

        return timeElapsed;

    }
    
    public async Task<int> DoSomethingAsyncVoidBad()
    {
        LongOperationSimulator.KeepRunningUntilAsyncVoid(5); //task execution begins
        return 1;

    }
    public async Task<int> DoSomethingAsyncVoidGood()
    {
        Task.Run(() => LongOperationSimulator.KeepRunningUntilAsyncVoid(5)); //task execution begins
        return 1;

    }

    /*
     For pre-computed results, there's no need to call Task.Run, that will end up queuing a work item to the
     thread pool that will immediately complete with the pre-computed value. Instead, use Task.FromResult, 
     to create a task wrapping already computed data.
    */
    public Task<int> AddAsyncGood(int a, int b)
    {
        return Task.FromResult(a + b);
    }
    
    public Task<int> AddAsyncBad(int a, int b)
    {
        return Task.Run(() => (a + b));
    }
    
    /*
     * This example uses a ValueTask<int> to return the trivially computed value.
     * It does not use any extra threads as a result.
     * It also does not allocate an object on the managed heap.
     */
    public ValueTask<int> AddAsyncWithValueTaskGood(int a, int b)
    {
        return new ValueTask<int>(a + b);
    }
}


