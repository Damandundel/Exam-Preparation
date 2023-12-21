

namespace war
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();
            int[] warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();
            int maxHealthSection = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Retire")
            {
                if (command[0] == "Fire")
                {
                    if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) < warShip.Length)
                    {
                        int index = int.Parse(command[1]);
                        int demage = int.Parse(command[2]);

                        warShip[index] -= demage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (command[0] == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int demage = int.Parse(command[3]);

                    if (startIndex >= 0 && endIndex < pirateShip.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= demage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine($"You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (command[0] == "Repair")
                {
                    if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) < warShip.Length)
                    {
                        int index = int.Parse(command[1]);
                        int addHealthSection = int.Parse(command[2]);

                        if (pirateShip[index] + addHealthSection > maxHealthSection)
                        {
                            pirateShip[index] = maxHealthSection;
                        }
                        else
                        {
                            pirateShip[index] += addHealthSection;
                        }
                    }
                }
                else if (command[0] == "Status")
                {
                    int counter = 0;
                    double attentionHealth = maxHealthSection * 0.2;

                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i] < attentionHealth)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine($"{counter} sections need repair.");
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}{Environment.NewLine}Warship status: {warShip.Sum()}");

        }
    }
}
