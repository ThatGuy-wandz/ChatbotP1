using System;
using System.Threading;

internal class ConsoleUI
{
  
    //Creates a typing effect or slight delay
   
    public static void TypeText(string text,ConsoleColor color = ConsoleColor.White,int delay = 30)
    {
        Console.ForegroundColor = color;
        foreach (char c in text)
        {
          Console.Write(c);
         Thread.Sleep(delay);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    // Creating dividers and boarders
     
    public static void PrintDivider(ConsoleColor color = ConsoleColor.DarkCyan)
    {
      Console.ForegroundColor = color;
       Console.WriteLine("═══════════════════════════════════════════════════════");
      Console.ResetColor();
    }

    public static void PrintThinDivider(ConsoleColor color = ConsoleColor.DarkGray)
    {
      Console.ForegroundColor = color;
     Console.WriteLine("───────────────────────────────────────────────────────");
      Console.ResetColor();
    }

    // Headers for sections
     
    public static void PrintHeader(string title, ConsoleColor color = ConsoleColor.Cyan)
    {
      Console.WriteLine();
      PrintDivider(color);
       Console.ForegroundColor = color;
       Console.WriteLine($"  ★  {title.ToUpper()}");
        PrintDivider(color);
        Console.ResetColor();
    }

    public static void PrintSubHeader(string title, ConsoleColor color = ConsoleColor.Yellow)
    {
         Console.WriteLine();
       Console.ForegroundColor = color;
         Console.WriteLine($"  ▶  {title}");
       PrintThinDivider();
        Console.ResetColor();
    }
    // Bot and user message display
    
    public static void PrintBotMessage(string message, string userName = "")
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("  🤖 Bot >> ");
        Console.ResetColor();
        TypeText(message, ConsoleColor.White, 20);
        Console.WriteLine();
    }

    public static void PrintUserPrompt(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"  👤 {userName} >> ");
        Console.ResetColor();
    }
     
    //  For error and success messages
    
    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  [✗] {message}\n");
        Console.ResetColor();
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  [✓] {message}\n");
        Console.ResetColor();
    }

    public static void PrintWarning(string message)
    {
       Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine($"\n  [!] {message}\n");
       Console.ResetColor();
    }


    // Gives the processing or loading animation
    
    public static void PrintLoading(string message = "Processing")
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"\n  {message}");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(400);
            Console.Write(".");
        }
        Console.WriteLine();
        Console.ResetColor();
        Thread.Sleep(200);
    }

    
    //Menu Section
     
    public static void PrintMenuBox(string[] topics)
    {
     Console.ForegroundColor = ConsoleColor.Cyan;
       Console.WriteLine("\n  ╔══════════════════════════════════════╗");
       Console.WriteLine("  ║         TOPICS YOU CAN ASK ABOUT    ║");
        Console.WriteLine("  ╠══════════════════════════════════════╣");
        foreach (string topic in topics)
        {
         Console.WriteLine($"  ║  • {topic,-35}║");
        }
        Console.WriteLine("  ╚══════════════════════════════════════╝\n");
        Console.ResetColor();
    }
}