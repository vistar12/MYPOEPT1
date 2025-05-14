using System;
using System.Collections.Generic;

namespace MYPOEPT1
{
    public class SentimentAnalyzer
    {
        
        
                private Dictionary<string, string> sentiments = new Dictionary<string, string>
        {
            {"worried", "It's understandable to feel that way. Here are some tips to stay safe."},
            {"curious", "Curiosity is the first step to becoming cybersecurity-savvy."},
            {"frustrated", "Cybersecurity can be tough, but you're doing great by asking questions."}
        };

        public bool DetectSentiment(string input)
        {
            foreach (var pair in sentiments)
            {
                if (input.Contains(pair.Key))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Artificial Intelligence: {pair.Value}");
                    return true;
                }
            }
            return false;
        }
    }
}

        