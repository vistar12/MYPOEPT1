using System;
using System.Collections.Generic;
using System.Linq;

namespace MYPOEPT1
{
    public class BotResponsemanager
    {
        
              private Dictionary<string[], string> responseMap = new Dictionary<string[], string>();

        public void InitializeResponses()
        {
            responseMap.Add(new[] { "firewall", "protection" }, "Firewalls help block unauthorized access.");
            responseMap.Add(new[] { "phishing", "email" }, "Phishing emails try to trick you. Stay alert.");
            responseMap.Add(new[] { "privacy", "settings" }, "Review your privacy settings regularly.");
            responseMap.Add(new[] { "update", "patch" }, "Keep systems updated to avoid known vulnerabilities.");
            responseMap.Add(new[] { "backup", "recovery" }, "Regular backups protect you from data loss.");
            // Add more as needed
        }

        public bool MatchAndRespond(string input)
        {
            foreach (var entry in responseMap)
            {
                if (entry.Key.Any(k => input.Contains(k)))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Artificial Intelligence: {entry.Value}");
                    return true;
                }
            }

            return false;
        }
    }
}

        