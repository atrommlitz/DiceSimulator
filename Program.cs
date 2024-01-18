// See https://aka.ms/new-console-template for more information
using System;

namespace DiceSimulator;
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

