using System;
namespace csgo
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int roundCounter = 0;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);
                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {roundCounter} won battles and {energy} energy");
                    return;
                }
                roundCounter++;

                energy -= distance;
                if (roundCounter % 3 == 0)
                {
                    energy += roundCounter;
                }
            }
            Console.WriteLine($"Won battles: {roundCounter}. Energy left: {energy}");
        }
    }
}
