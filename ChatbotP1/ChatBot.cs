using System;
using System.Threading;

internal class ChatBot
{
    private string _userName;

    public ChatBot(string userName)
    {
        _userName = userName;
    }

    //basic Response System
    
    public string GetResponse(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
            return DisplayError("Input cannot be empty. Please type a question.");

        string input = userInput.ToLower().Trim();

        //  For the general conversation
        if (input.Contains("how are you"))
            return $"I'm doing great, {_userName}! Ready to help you stay safe online.";

        if (input.Contains("what's your purpose") || input.Contains("what is your purpose"))
            return $"My purpose is to help you, {_userName}, learn about cybersecurity and how to stay safe online!";

        if (input.Contains("what can i ask you about") || input.Contains("what can you do") || input.Contains("help"))
            return $"You can ask me about:\n" +
                   $"  • Password safety\n" +
                   $"  • Phishing attacks\n" +
                   $"  • Safe browsing\n" +
                   $"  • and more cybersecurity topics!";

        if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            return $"Hey there, {_userName}! How can I help you stay safe online today?";

        if (input.Contains("thank") || input.Contains("thanks"))
            return $"You're welcome, {_userName}! Stay safe out there!";

        //Password Safety
        if (input.Contains("password"))
            return $"Great question, {_userName}! Here are some password safety tips:\n" +
                   $"  • Use at least 12 characters\n" +
                   $"  • Mix uppercase, lowercase, numbers and symbols\n" +
                   $"  • Never reuse passwords across sites\n" +
                   $"  • Use a password manager\n" +
                   $"  • Enable two-factor authentication (2FA)";

        // ── Phishing ──
        if (input.Contains("phishing") || input.Contains("phish"))
            return $"Phishing is when attackers trick you into revealing personal info, {_userName}.\n" +
                   $"  • Never click suspicious links in emails\n" +
                   $"  • Check the sender's email address carefully\n" +
                   $"  • Legitimate companies won't ask for passwords via email\n" +
                   $"  • When in doubt, go directly to the website";

        //Safe Browsing
        if (input.Contains("browsing") || input.Contains("browse") || input.Contains("internet") || input.Contains("website"))
            return $"Here are safe browsing tips for you, {_userName}:\n" +
                   $"  • Always look for HTTPS in the URL\n" +
                   $"  • Avoid public Wi-Fi for sensitive activities\n" +
                   $"  • Keep your browser updated\n" +
                   $"  • Use an ad blocker to avoid malicious ads\n" +
                   $"  • Don't download files from unknown sources";

        //  Malware 
        if (input.Contains("malware") || input.Contains("virus") || input.Contains("antivirus"))
            return $"Protecting against malware, {_userName}:\n" +
                   $"  • Install reputable antivirus software\n" +
                   $"  • Keep your OS and apps updated\n" +
                   $"  • Don't open email attachments from strangers\n" +
                   $"  • Avoid pirated software";

        // 2FA
        if (input.Contains("two factor") || input.Contains("2fa") || input.Contains("authentication"))
            return $"Two-Factor Authentication (2FA) adds an extra layer of security, {_userName}!\n" +
                   $"  • Enable it on all important accounts\n" +
                   $"  • Use an authenticator app instead of SMS when possible\n" +
                   $"  • Never share your 2FA codes with anyone";

        //Exit
        if (input.Contains("exit") || input.Contains("quit") || input.Contains("bye"))
            return "QUIT";

        //For Default response for unsupported queries
        return DisplayError($"I didn't quite understand that, {_userName}. Could you rephrase?\n" +
                            $"     Try asking about: passwords, phishing, safe browsing, or malware.");
    }

 
    //  This is for the  Input Validation
    
    private string DisplayError(string message)
    {
        return $"[!] {message}";
    }
    //  This is the Enhanced Console UI
    
    public void StartChat()
    {
        bool isRunning = true;

        ConsoleUI.PrintHeader("Cybersecurity Awareness Bot");
        ConsoleUI.PrintMenuBox(new string[]
        {
            "Password Safety",
            "Phishing Attacks",
            "Safe Browsing",
            "Malware & Viruses",
            "Two-Factor Authentication (2FA)",
            "Type 'exit' to quit"
        });

        while (isRunning)
        {
            ConsoleUI.PrintUserPrompt(_userName);
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                ConsoleUI.PrintError("Input cannot be empty. Please type a question.");
                continue;
            }

            ConsoleUI.PrintLoading("Thinking");

            string response = GetResponse(userInput);

            if (response == "QUIT")
            {
                ConsoleUI.PrintDivider();
                ConsoleUI.TypeText($"\n  Goodbye, {_userName}! Stay safe online! \n",
                                   ConsoleColor.Cyan, 40);
                ConsoleUI.PrintDivider();
                isRunning = false;
                continue;
            }

            if (response.StartsWith("[!]"))
                ConsoleUI.PrintWarning(response.Replace("[!] ", ""));
            else
                ConsoleUI.PrintBotMessage(response);

            ConsoleUI.PrintThinDivider();
        }
    }
}

