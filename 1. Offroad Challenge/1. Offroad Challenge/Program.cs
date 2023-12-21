namespace offroad_challenge
{
    class Program
    {
        static void Main()
        {
            int[] initialFuel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] consumptionIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] neededFuel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int altitudesCount = initialFuel.Length;

            for (int i = 0; i < altitudesCount; i++)
            {
                int currentAltitudeFuel = initialFuel.Last() - consumptionIndexes.First();

                if (currentAltitudeFuel >= neededFuel.First())
                {
                    Console.WriteLine($"John has reached: Altitude {i + 1}");

                    initialFuel = initialFuel.Take(altitudesCount - i - 1).ToArray();
                    consumptionIndexes = consumptionIndexes.Skip(1).ToArray();
                    neededFuel = neededFuel.Skip(1).ToArray();
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {i + 1}");

                    if (i > 0)
                    {
                        Console.WriteLine($"John failed to reach the top.\nReached altitudes: {string.Join(", ", Enumerable.Range(1, i))}");
                    }
                    else
                    {
                        Console.WriteLine("John failed to reach the top.\nJohn didn't reach any altitude.");
                    }

                    return;
                }
            }

            Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
        }
    }
}