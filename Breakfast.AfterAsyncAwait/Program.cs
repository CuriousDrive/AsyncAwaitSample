using System;
using System.Threading.Tasks;

namespace Breakfast.AfterAsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;
            
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var taskFryEggs = FryEggsAsync(2);
            var taskFryBacon = FryBaconAsync(3);
            var taskToastBread = ToastBreadAsync(2);

            Egg eggs = await taskFryEggs;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await taskFryBacon;
            Console.WriteLine("bacon is ready");

            Toast toast = await taskToastBread;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!\n");

            var endTime = DateTime.Now;

            Console.WriteLine("Total Time : " + (endTime - startTime).Seconds + " minutes");
        }

        // Methods

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async static Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private async static Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private async static Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
        
        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }
        
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }
}
