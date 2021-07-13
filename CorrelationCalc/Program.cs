using System;

namespace CorrelationCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var durationCalcOk = DurationCalcByDay.RunTests();
            Console.WriteLine($"Duration Calc OK: {durationCalcOk}");
            
            

            Console.WriteLine("Bye!");
        }
    }
}