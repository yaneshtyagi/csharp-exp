using System;
using System.Threading;
using System.Threading.Tasks;

public class LongOperationSimulator{
    public static int KeepRunningUntil(int seconds){
        var beginTime = DateTime.Now;
        while(true){
            if(System.DateTime.Now.Subtract(beginTime).Seconds > seconds) break;
            Thread.Sleep(100); //sleep for 100 milliseconds
        }
        Console.Write($"Time elapsed: {System.DateTime.Now.Subtract(beginTime).Seconds} seconds ");
        return System.DateTime.Now.Subtract(beginTime).Seconds;
    }    

    public static async Task<int> KeepRunningUntilAsync(int seconds){
        var beginTime = DateTime.Now;
        Console.WriteLine($"Starting job at {beginTime} ");
        while(true){
            if(System.DateTime.Now.Subtract(beginTime).Seconds > seconds) break;
            //Thread.Sleep(100); //Thread.sleep makes the method synchronous and then whole pipeline runs in sync
            await Task.Delay(500); //use this for async
        }
        Console.WriteLine($"Time elapsed: {System.DateTime.Now.Subtract(beginTime).Seconds} seconds ");
        return System.DateTime.Now.Subtract(beginTime).Seconds;
    }    

    public static async void KeepRunningUntilAsyncVoid(int seconds){
        var beginTime = DateTime.Now;
        Console.WriteLine($"Starting job at {beginTime} ");
        while(true){
            if(System.DateTime.Now.Subtract(beginTime).Seconds > seconds) break;
            //Thread.Sleep(100); //Thread.sleep makes the method synchronous and then whole pipeline runs in sync
            await Task.Delay(500); //use this for async
        }
        Console.WriteLine($"Time elapsed: {System.DateTime.Now.Subtract(beginTime).Seconds} seconds ");
        return;
    }  
}