

class Program
{
    static void Main()
    {
        List<int> armorValue = Console.ReadLine()
            .Split(',')
            .Select(int.Parse)
            .ToList();
        List<int> strikingValues = Console.ReadLine()
            .Split(',')
            .Select(int.Parse)
            .ToList();

        int killedMonsters = 0;

        while (armorValue.Any() && strikingValues.Any())
        {
            int currentMonsterArmor = armorValue.First();
            int currentStrike = strikingValues.Last();

            if (currentStrike >= currentMonsterArmor)
            {
                armorValue.RemoveAt(0);
                strikingValues.RemoveAt(strikingValues.Count - 1);

                int remainingImpact = currentStrike - currentMonsterArmor;

                if (strikingValues.Any())
                {
                    strikingValues[strikingValues.Count - 1] += remainingImpact;
                }
            }
            else
            {
                armorValue[0] -= currentStrike;
                strikingValues.RemoveAt(strikingValues.Count - 1);
                armorValue.Add(armorValue[0]);
                armorValue.RemoveAt(0);
            }

            killedMonsters++;
        }

        if (armorValue.Any())
        {
            Console.WriteLine("The soldier has been defeated.");
             Console.WriteLine($"Total monsters killed: {killedMonsters - 1}");
        }
        else
        {
            Console.WriteLine("All monsters have been killed!");
             Console.WriteLine($"Total monsters killed: {killedMonsters}");
        }
    }
}
