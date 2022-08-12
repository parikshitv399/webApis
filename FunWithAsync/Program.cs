using System;
using System.Threading.Tasks;

namespace FunWithAsync
{
    class Program
    {
        static void Main()
        {
            M1();                   //Engine won't allow it to run independently
            M2();                   //even if the method is asynchronoulsy, possibility that system hangs

            Task.Run(() => M1());   //Forcing it to execute independently haphazard
            Task.Run(() => M2());   //system will not hang

            M3();                   //Async married to await, exec sequential and independent
                                    //system will not hang
            Console.WriteLine("Main ended");
        }
        private async static void M3()
        {
            await M1();                       //executes independently in sequence        
            await M2();                       //asynchronously
        }

        private async static Task M1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"In method 1 for the {i}th time");
            }
        }

        private async static Task M2()
        {
            for (int i = 1001; i < 10000; i++)
            {
                Console.WriteLine($"In method 2 for the {i}th time");
            }
        }
    }
}