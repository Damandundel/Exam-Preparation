
namespace bonus_score
{
    class Program
    {
        static void Main(string[] args)
        {
            int student = int.Parse(Console.ReadLine());
            int lecture = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            int maxAttendances = 0;

            for (int i = 0; i < student; i++)
            {
                int attendance = int.Parse(Console.ReadLine());
                double currentBonus = (attendance / (double)lecture) * (5 + additionalBonus);

                if (currentBonus > maxBonus)
                {
                    maxBonus = currentBonus;

                    maxAttendances = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");

        }

    }
}
