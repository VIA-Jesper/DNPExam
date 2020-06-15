using System;
using GasPump;

namespace PumpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReturnCost();
            TestFillPump();
        }


        /// <summary>
        /// Tests return costs. Ordinarily xUnit would have been used
        /// </summary>

        private static void TestReturnCost()
        {
            // arrange
            var pump = new Pump();
            double[] tankSize = {42, 23, 112, 12, 4};

            // act
            var val1 = pump.CostOfFullTank((decimal) tankSize[0]);
            var val2 = pump.CostOfFullTank((decimal) tankSize[1]);
            var val3 = pump.CostOfFullTank((decimal) tankSize[2]);
            var val4 = pump.CostOfFullTank((decimal) tankSize[3]);
            var val5 = pump.CostOfFullTank((decimal) tankSize[4]);


            // assert
            Console.WriteLine(val1);
            Console.WriteLine(val2);
            Console.WriteLine(val3);
            Console.WriteLine(val4);
            Console.WriteLine(val5);
        }


        private static void TestFillPump()
        {
            // arrange
            var pump = new Pump();

            // act
            var val1 = pump.FillPump();


            // assert
            Console.WriteLine(val1);
            if (val1.Second != DateTime.Now.Second &&
                val1.Minute != DateTime.Now.Minute &&
                val1.Hour != DateTime.Now.Hour &&
                val1.Day != DateTime.Now.Day &&
                val1.Month != DateTime.Now.Month &&
                val1.Year != DateTime.Now.Year)
            {
                Console.WriteLine("Time does not display correctly.");
            }
            else
            {
                Console.WriteLine("Time is correct.");


                TimeSpan span = DateTime.Now - val1;
                double totalMs = span.TotalMilliseconds;
                Console.WriteLine("Pump was filled " + totalMs + "ms before this test.");


            }
        }
    }
}
