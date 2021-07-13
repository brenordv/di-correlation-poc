using System;

namespace CorrelationCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var durationCalcOk = DurationCalcByDay.RunTests();
            Console.WriteLine($"Duration Calc OK:\t{durationCalcOk}");

            var splitDtOk = SplitDateTimeByDay.RunTests();
            Console.WriteLine($"Split DateTime OK:\t{splitDtOk}");
            

            Console.WriteLine("Bye!");
        }
    }
}