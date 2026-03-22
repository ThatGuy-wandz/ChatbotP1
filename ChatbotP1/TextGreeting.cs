using System;

internal class TextGreeting
{
    public static string GetUserName()
    {
        ConsoleUI.PrintSubHeader("Let's get started!");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n  Please enter your name: ");
        Console.ResetColor();

        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            ConsoleUI.PrintError("Name cannot be empty. Please enter your name: ");
            Console.Write("  Name: ");
            name = Console.ReadLine();
        }

        return name;
    }

    public static void DisplayWelcomeMessage(string name)
    {
        ConsoleUI.PrintDivider(ConsoleColor.Green);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Welcome, {name}!");
        Console.WriteLine($"  I'm your Cybersecurity Awareness Bot  Assistant.");
        Console.WriteLine($"  I'm here to help you stay safe online.");
        ConsoleUI.PrintDivider(ConsoleColor.Green);
        Console.ResetColor();
    }
}
