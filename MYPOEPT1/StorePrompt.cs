using System;
using System.Collections.Generic;

namespace MYPOEPT2
{
    public class StorePrompt
    {
        MemoryRecall recall = new MemoryRecall();
        private Dictionary<string, string> botResponses = new Dictionary<string, string>();
        private Dictionary<string, List<string>> randomResponses = new Dictionary<string, List<string>>();
        private List<string> wordsToIgnore = new List<string>();
        private List<string> exitWords = new List<string>();
        private Random rand = new Random();

        private Dictionary<string, string> sentimentResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe." },
            { "curious", "Great to hear you're curious! Learning more about cybersecurity is a smart move." },
            { "frustrated", "I'm sorry you're feeling frustrated. Cybersecurity can be tricky, but I'm here to help!" }
        };

        public StorePrompt()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Welcome to the Vistar Cyber Security Bot:");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            RunBot();
        }

        public void StoreBotResponses()
        {
            botResponses.Add("ransomware", "Ransomware locks your data and demands payment. Backup your data regularly.");
            botResponses.Add("cyberattack", "A cyberattack can expose sensitive information. Preparedness is key.");
            botResponses.Add("backup", "Regular backups can save you from losing important files during an attack.");
            botResponses.Add("credentials", "Protect your credentials by using strong, unique passwords.");
            botResponses.Add("incident", "An incident response plan ensures cybersecurity breaches are handled properly.");
            botResponses.Add("cookies", "Cookies can track your online activities. Clear them regularly for privacy.");
        }

        public void StoreRandomResponses()
        {
            randomResponses.Add("phishing", new List<string>
            {
                "Be cautious of emails asking for personal info.",
                "Check the sender's email address carefully.",
                "Avoid clicking suspicious links or attachments.",
                "Use anti-phishing tools and stay informed."
            });

            randomResponses.Add("password", new List<string>
            {
                "Use a password manager to store complex passwords.",
                "Never reuse the same password across multiple sites.",
                "Enable two-factor authentication wherever possible.",
                "Avoid sharing your passwords with anyone."
            });

            randomResponses.Add("malware", new List<string>
            {
                "Malware can be hidden in attachments or downloads.",
                "Install and update antivirus software regularly.",
                "Avoid downloading files from unknown sources.",
                "Be cautious of pop-up ads or software installs."
            });

            randomResponses.Add("firewall", new List<string>
            {
                "Firewalls help block unauthorized access.",
                "Enable firewalls on all network-connected devices.",
                "Update firewall settings to match your security needs.",
                "Use both software and hardware firewalls where possible."
            });

            randomResponses.Add("vpn", new List<string>
            {
                "A VPN masks your IP address and encrypts your traffic.",
                "Use a reliable VPN when on public Wi-Fi.",
                "VPNs enhance online privacy and bypass geo-restrictions.",
                "Do not use free VPNs that log your data."
            });

            randomResponses.Add("encryption", new List<string>
            {
                "Encryption keeps data safe during storage and transmission.",
                "Use end-to-end encryption for sensitive messages.",
                "Avoid using weak or outdated encryption methods.",
                "Encrypted files can only be accessed with the correct key."
            });
        }

        public void StoreWordsToIgnore()
        {
            wordsToIgnore.AddRange(new string[] { "a", "an", "the", "is", "are", "to", "of", "and" });
        }

        public void StoreExitWords()
        {
            exitWords.AddRange(new string[] { "exit", "quit", "bye", "stop" });
        }

        public bool CheckInput(string user_input)
        {
            if (string.IsNullOrWhiteSpace(user_input) || user_input.Contains("  "))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Artificial Intelligence: Name is invalid, please enter a proper name.");
                Console.ResetColor();
                return false;
            }
            return true;
        }
        
        public void RunBot()
        {
            StoreBotResponses();
            StoreRandomResponses();
            StoreWordsToIgnore();
            StoreExitWords();

            bool running = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Artificial Intelligence: Welcome to the AI Bot, may I get your name?");
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("User: ");
                name = Console.ReadLine();
            } while (!CheckInput(name));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Artificial Intelligence: Thank you, {name}. Please ask a cybersecurity-related question to get started.");

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{name}: ");
                string userInput = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Artificial Intelligence: I didn't catch that. Please enter your question.");
                    continue;
                }

                if (exitWords.Contains(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("****************************************************************************");
                    Console.WriteLine("Artificial Intelligence: Thank you for chatting. Goodbye!");
                    Console.WriteLine("****************************************************************************");
                    Console.ResetColor();
                    running = false;
                    break;
                }

                if (userInput == "what are my interests")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Artificial Intelligence: Here are your saved interests:");
                    recall.DisplayUserInterests(name);

                    continue;
                }

              
                if (userInput.Contains("i am interested in") || userInput.Contains("i'm interested in"))
                {
                    string interests = "";

                    if (userInput.Contains("i am interested in"))
                        interests = userInput.Substring(userInput.IndexOf("i am interested in") + "i am interested in".Length).Trim();

                    else if (userInput.Contains("i'm interested in"))
                        interests = userInput.Substring(userInput.IndexOf("i'm interested in") + "i'm interested in".Length).Trim();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Artificial Intelligence: Got it! I'll remember you're interested in {interests}.");
                    Console.ResetColor();

                    recall.StoreInterest(name, interests); 
                    continue;
                }


                bool matchFound = false;
                string combine_response = string.Empty;

                string sentimentResponse = string.Empty;
                foreach (var sentiment in sentimentResponses)
                {
                    if (userInput.Contains(sentiment.Key))
                    {
                        sentimentResponse = sentiment.Value;
                        break;
                    }
                }

                foreach (var pair in randomResponses)
                {
                    if (userInput.Contains(pair.Key))
                    {
                        var responses = pair.Value;
                        int index = rand.Next(responses.Count);
                        combine_response = responses[index];
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (!string.IsNullOrEmpty(sentimentResponse))
                        {
                            Console.WriteLine($"Artificial Intelligence: {sentimentResponse} {combine_response}");
                            combine_response = $"{sentimentResponse} {combine_response}";
                        }
                        else
                        {
                            Console.WriteLine($"Artificial Intelligence: {combine_response}");
                        }
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    foreach (var pair in botResponses)
                    {
                        if (userInput.Contains(pair.Key))
                        {
                            combine_response = pair.Value;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (!string.IsNullOrEmpty(sentimentResponse))
                            {
                                Console.WriteLine($"Artificial Intelligence: {sentimentResponse} {combine_response}");
                                combine_response = $"{sentimentResponse} {combine_response}";
                            }
                            else
                            {
                                Console.WriteLine($"Artificial Intelligence: {combine_response}");
                            }
                            matchFound = true;
                            break;
                        }
                    }
                }

                if (!matchFound)
                {
                    combine_response = "Sorry, I do not have a response for your question.";
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (!string.IsNullOrEmpty(sentimentResponse))
                    {
                        Console.WriteLine($"Artificial Intelligence: {sentimentResponse} {combine_response}");
                        combine_response = $"{sentimentResponse} {combine_response}";
                    }
                    else
                    {
                        Console.WriteLine($"Artificial Intelligence: {combine_response}");
                    }
                }

               
            }
        }
    }
}
