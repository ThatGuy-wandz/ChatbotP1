using System;
using System.Media;
using System.IO;

internal class VoiceGreeting
{
    public static void PlayVoiceGreeting()
    {
       // Seting  the name of my WAV file here
        string audioFileName = "greeting.wav";

      // This looks for the WAV file in the same folder as  where my  program is saved
        string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, audioFileName);

        if (File.Exists(audioFilePath))
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    player.PlaySync();
                    Console.WriteLine("[Voice greeting was played successfully]\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not play audio: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"[Warning: greeting.wav not found at {audioFilePath}]");
            Console.WriteLine("Please add your WAV file to the project.\n");
        }
    }
}
