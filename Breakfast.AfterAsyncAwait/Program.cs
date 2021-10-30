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

            var taskEggs = FryEggsAsync(2);
            var taskBacon = FryBaconAsync(3);
            var taskToast = ToastBreadAsync(2);

            Toast toast = await taskToast;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Egg eggs = await taskEggs;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await taskBacon;
            Console.WriteLine("bacon is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!\n");

            var endTime = DateTime.Now;

            Console.WriteLine("Total Time : " + (endTime - startTime).Seconds + " minutes \n");
        }

        // Methods

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async static Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(6000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
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
