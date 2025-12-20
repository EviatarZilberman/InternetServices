using Delegations.Classes;
using Delegations.Interfaces;

namespace Delegations
{
    class Program
    {
        delegate void LogDel(string log);

        LogDel logDel = new LogDel(LogTextToScreen);
        static void Main(string[] args)
        {
            ILog screenLogger = new ScreenLog();
            ILog fileLogger = new FileLog();
            //// Instantiate the delegate with a method
            //LogDel logDel = new LogDel(logger.Log);

            //// Call the delegate
            //logDel("Some Text!");
            //Console.ReadLine();

            LogDel screenDel = new LogDel(screenLogger.Log);
            LogDel fileDel = new LogDel(fileLogger.Log);

            LogDel multiLog = screenDel + fileDel;
            multiLog($"{DateTime.Now} Eviatar Zilberman");
        }

        public static void LogTextToScreen(string log)
        {
            Console.WriteLine($"{DateTime.UtcNow}: {log}");
        }
    }
}