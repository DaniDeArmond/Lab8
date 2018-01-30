using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Validation
    {
        public static int ValidateInteger(string Input)
        {
            int Answer;
            while (int.TryParse(Input, out int Result) != true)
            {
                Console.WriteLine("You did not enter a valid number choice. Please try again.");
                Input = Console.ReadLine();
            }
            Answer = int.Parse(Input);
            return Answer;
        }
    }

    public class Baseball
    {
        public static int[][] GetStats(int AtBats, int Batters)
        {
            int[][] BattingStats = new int[Batters][];
            int Temp = 0;

            for (int i = 0; i < Batters; i++)
            {
                Console.WriteLine($"Enter the stats for a batter {i+1}.");

                Console.Write("\n 0 = Out \n 1 = Single \n 2 = Double \n 3 = Triple \n 4 = Home Run \n");

                BattingStats[i] = new int[AtBats];
                for (int j = 0; j < AtBats; j++)
                {
                    Console.WriteLine($"Result for at-bat {j+1}: ");
                    Temp = Validation.ValidateInteger(Console.ReadLine());
                    BattingStats[i][j] = Temp;
                }
            }
            return BattingStats;
        }
        public static double SluggingPercentage(int[][] BattingStats, int BatterIndex)
        {
            double SumAtBats = 0, AtBatsValue = -1, MaxValue, SluggingPerc = -1;

            MaxValue = BattingStats[BatterIndex].Length;

            for (int i = 1; i <= MaxValue; i++)
            {
                AtBatsValue = BattingStats[BatterIndex][i-1];
                if (AtBatsValue > 0)
                {
                    SumAtBats += AtBatsValue;
                }
            }
            SluggingPerc = SumAtBats / MaxValue;
            return SluggingPerc;
        }
        public static double BattingAverage(int[][] BattingStats, int BatterIndex)
        {
            double CountAtBats = 0, AtBatsValue = 0, MaxValue, BatAverage = 0;
            MaxValue = BattingStats[BatterIndex].Length;
            for (int i = 1; i <= MaxValue; i++)
            {
                AtBatsValue = BattingStats[BatterIndex][i-1];
                if (AtBatsValue > 0)
                {
                    CountAtBats++;
                }
            }
            BatAverage = CountAtBats / MaxValue;
            return BatAverage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Baseball MyBaseball = new Baseball();
            Validation MyValidation = new Validation();
            string Input, DoAgain;
            int[][] MyBattingStats;
            int MyAtBats, MyBatters, Row;
            bool Repeat1 = true, Repeat2 = true;

            while (Repeat1 == true)
            {
                Console.WriteLine("How many batters?");
                Input = Console.ReadLine();
                while (!int.TryParse(Input, out int Result))
                {
                    Console.WriteLine("You did not enter a valid integer value. Please try again.");
                    Input = Console.ReadLine();
                }

                Console.WriteLine("How many times at bat?");
                MyAtBats = Validation.ValidateInteger(Console.ReadLine());

                MyBatters = int.Parse(Input);
                MyBattingStats = Baseball.GetStats(MyAtBats, MyBatters);

                for (Row = 0; Row <= MyBatters - 1; Row++)
                {
                    Console.WriteLine($"The Batting Average of Batter {Row + 1} is {Baseball.BattingAverage(MyBattingStats, Row)}.");
                    Console.WriteLine($"The Slugging Percentage of Batter {Row + 1} is {Baseball.SluggingPercentage(MyBattingStats, Row)}.");
                }
                Console.WriteLine("Would you like to run this program again? (Y or N)");
                DoAgain = Console.ReadLine();

                while (Repeat2 == true)
                {
                    if (string.Compare(DoAgain, "N", true) == 0)
                    {
                        Console.WriteLine("Press enter to end the program. Goodbye!");
                        Repeat1 = false;
                        Repeat2 = false;
                        Console.Read();
                    }
                    else if (string.Compare(DoAgain, "Y", true) == 0)
                    {
                        Repeat2 = false;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter 'Y' or 'N'. Please enter 'Y' to run the program again, or enter 'N' to end the program now.");
                        DoAgain = Console.ReadLine();
                    }
                }
            }
        }
    }
}
