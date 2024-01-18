// See https://aka.ms/new-console-template for more information
public class Program
{
    private static void Main()
    {
        System.Console.WriteLine("Welcome to the dice throwing simulator");

        System.Console.WriteLine("How many dice rolls would you like to simulate? ");
        string userInput = System.Console.ReadLine();

        if (userInput != null)
        {
            int numberOfRolls = int.Parse(userInput);

            DiceRoller diceRoller = new DiceRoller();
            int[] results = diceRoller.SimulateDiceRolls(numberOfRolls);

            PrintHistogram(results, numberOfRolls);
        }
        else
        {
            System.Console.WriteLine("Invalid input. Please enter a valid number of dice rolls.");
        }

        System.Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    static void PrintHistogram(int[] results, int totalRolls)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.\n");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i] * 100 / totalRolls;
            Console.WriteLine($"{i}: {new string('*', percentage)}");
        }
    }
}

class DiceRoller
{
    private Random random;

    public DiceRoller()
    {
        random = new Random();
    }

    public int[] SimulateDiceRolls(int numberOfRolls)
    {
        int[] results = new int[13]; // Index 0 is not used, results for 2 to 12 are stored at indices 2 to 12

        for (int i = 0; i < numberOfRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            int sum = dice1 + dice2;
            results[sum]++;
        }

        return results;
    }
}