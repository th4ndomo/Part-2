using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System;
using System.Drawing;

namespace Part_2
{
    internal class Chatbot
    {
        public Chatbot()
        {
            // Memory storage
            string userName = "";
            string userInterest = "";

            // Sentiment keywords
            string[] positiveSentiments = { "good", "great", "happy", "fine", "okay" };
            string[] negativeSentiments = { "worried", "scared", "anxious", "nervous", "frustrated", "confused" };

            string project_location = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(project_location);
            string updated_path = project_location.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(updated_path, "Audio.wav");
            Play_Sound(full_path);
            Ascii_Art();

            Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>
        {
            { "phishing", new List<string> {
                "AI: Be cautious of emails asking for personal information.",
                "AI: Check the sender’s email address before clicking on links.",
                "AI: Avoid downloading attachments from unknown sources."
            }},
            { "password", new List<string> {
                "AI: Use strong, unique passwords for each account.",
                "AI: Avoid personal details like birthdays in your passwords.",
                "AI: Consider using a password manager for safety."
            }},
            { "privacy", new List<string> {
                "AI: Review privacy settings on social media regularly.",
                "AI: Limit sharing sensitive data online.",
                "AI: Use encrypted messaging apps when possible."
            }},
            { "scam", new List<string> {
                "AI: Scammers often pose as legitimate organizations.",
                "AI: Always verify suspicious emails or calls independently.",
                "AI: Be wary of messages that create urgency or fear."
            }},
            { "safe browsing", new List<string> {
                "AI: Keep your browser and antivirus up to date.",
                "AI: Don’t click suspicious pop-ups or ads.",
                "AI: Use HTTPS websites for secure transactions."
            }}
        };

            Console.WriteLine("===================================================================================================================================================================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI: Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI: What is your name?");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            userName = Console.ReadLine();
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI: Hi " + userName + ", how are you feeling today?");
            Console.WriteLine("==================================================================================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            string sentimentInput = Console.ReadLine().ToLower();
            Console.WriteLine("==================================================================================================");

            if (negativeSentiments.Any(s => sentimentInput.Contains(s)))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("AI: It's completely understandable to feel that way, " + userName + ". Let me share some tips to help you stay safe.");
            }
            else if (positiveSentiments.Any(s => sentimentInput.Contains(s)))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("AI: I'm glad to hear that, " + userName + "! Let's keep it that way by staying informed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("AI: Thanks for sharing, " + userName + ". Let me know how I can help.");
            }

            Console.WriteLine("==================================================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI: What would you like to know about cybersecurity?");
            Console.WriteLine("==================================================================================================");

            string userInput;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User: ");
                userInput = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine("==================================================================================================");

                bool topicFound = false;

                foreach (var entry in topics)
                {
                    if (userInput.Contains(entry.Key))
                    {
                        Random rnd = new Random();
                        string response = entry.Value[rnd.Next(entry.Value.Count)];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(response);
                        topicFound = true;

                        if (string.IsNullOrEmpty(userInterest))
                        {
                            userInterest = entry.Key;
                            Console.WriteLine("AI: Great! I'll remember that you're interested in " + userInterest + ".");
                        }
                        else
                        {
                            Console.WriteLine($"AI: As someone interested in {userInterest}, here's another tip for you.");
                        }
                        break;
                    }
                }

                if (!topicFound && userInput != "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AI: I'm not sure I understand. Could you try rephrasing?");
                    Console.WriteLine("==================================================================================================");
                }

                if (userInput != "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AI: Anything else I can help you with? If not, type 'exit' to quit.");
                }

            } while (userInput != "exit");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AI: Thank you for using Chatbot. Stay safe online!");
        }

        private void Play_Sound(string full_path)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void Ascii_Art()
        {
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            string new_path_project = path_project.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(new_path_project, "Prog Log.jpeg");

            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(210, 200));

            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    Console.Write(ascii_design);
                }
                Console.WriteLine();
            }
        }
    }

}
    