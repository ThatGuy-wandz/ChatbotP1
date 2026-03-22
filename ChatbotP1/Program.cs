using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ChatbotP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageDisplay.ShowAsciiArt();
            VoiceGreeting.PlayVoiceGreeting();
            string username =TextGreeting.GetUserName();
            TextGreeting.DisplayWelcomeMessage(username);
            ChatBot responsebot = new ChatBot(username);
            responsebot.StartChat();
        }
    }
}
