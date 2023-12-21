using System;

class Program
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int dailyPlunders = int.Parse(Console.ReadLine());
        double expectedPlunders = double.Parse(Console.ReadLine());

        double totalPlunders = 0;

        for (int day = 1; day <= days; day++)
        {
            totalPlunders += dailyPlunders;

            if (day % 3 == 0)
            {
                totalPlunders += 0.5 * dailyPlunders;
            }

            if (day % 5 == 0)
            {
                totalPlunders -= 0.3 * totalPlunders;
            }
        }

        if (totalPlunders >= expectedPlunders)
        {
            Console.WriteLine($"Ahoy! {totalPlunders:f2} plunder gained.");
        }
        else
        {
            double percentageCollected = (totalPlunders / expectedPlunders) * 100;
             Console.WriteLine($"Collected only {percentageCollected:f2}% of the plunder.");
        }
    }
}

