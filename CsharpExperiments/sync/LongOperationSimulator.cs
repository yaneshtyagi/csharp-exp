public class LongOperationSimulator{
    public static void KeepRunningUntil(int seconds){
        var beginTime = DateTime.Now;
        while(true){
            if(System.DateTime.Now.Subtract(beginTime).ToSeconds() > seconds) break;
            sleep(100); //sleep for 100 milliseconds
            
        }
    }    

}