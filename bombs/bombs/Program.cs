namespace bombs
{


    class Program
    {
        static void Main()
        {
            List<int> bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            List<int> bombCasings = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Dictionary<string, int> bombs = new Dictionary<string, int>
        {
            { "Cherry Bombs", 0 },
            { "Datura Bombs", 0 },
            { "Smoke Decoy Bombs", 0 }
        };

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int sum = bombEffects.First() + bombCasings.Last();

                if (IsBombCreated(sum))
                {
                    string bombType = GetBombType(sum);
                    bombs[bombType]++;
                    bombEffects.RemoveAt(0);
                    bombCasings.RemoveAt(bombCasings.Count - 1);
                }
                else
                {
                    bombCasings[bombCasings.Count - 1] -= 5;
                }

                if (AreBombsReady(bombs))
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    PrintRemainingItems("Bomb Effects", bombEffects);
                    PrintRemainingItems("Bomb Casings", bombCasings);
                    PrintBombs(bombs);
                    return;
                }
            }

            Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            PrintRemainingItems("Bomb Effects", bombEffects);
            PrintRemainingItems("Bomb Casings", bombCasings);
            PrintBombs(bombs);
        }

        static bool IsBombCreated(int sum)
        {
            return sum == 40 || sum == 60 || sum == 120;
        }

        static string GetBombType(int sum)
        {
            switch (sum)
            {
                case 40: return "Datura Bombs";
                case 60: return "Cherry Bombs";
                case 120: return "Smoke Decoy Bombs";
                default: return string.Empty;
            }
        }

        static bool AreBombsReady(Dictionary<string, int> bombs)
        {
            return bombs.Values.All(count => count >= 3);
        }

        static void PrintRemainingItems(string itemType, List<int> items)
        {
            Console.WriteLine($"{itemType}: {(items.Count == 0 ? "empty" : string.Join(", ", items))}");
        }

        static void PrintBombs(Dictionary<string, int> bombs)
        {
            foreach (var kvp in bombs.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }

}