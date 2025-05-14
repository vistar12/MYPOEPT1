using System;
using System.Collections.Generic;
using System.IO;

namespace MYPOEPT2
{
    internal class MemoryRecall
    {
                private string filepath;

            public MemoryRecall()
            {
                // Get full path of project directory and adjust the path
                string full_path = AppDomain.CurrentDomain.BaseDirectory;
                string newpath = full_path.Replace("bin\\Debug\\", "");
                filepath = Path.Combine(newpath, "MemoryStoring.txt");
                 

                List<string> memory_stored = LoadMemory(filepath);

                
            }

            // Method to load stored memory from file
            private List<string> LoadMemory(string path)
            {
                if (File.Exists(path))
                {
                    return new List<string>(File.ReadAllLines(path));
                }
                else
                {
                    File.CreateText(path);
                    return new List<string>();
                }
            }

        // created a method to store the user input and the bot response
        public void StoreUserInput(string type, string username, string content)
        {
            List<string> memory_stored = LoadMemory(filepath);

            if (type == "Interest")
            {
                memory_stored.Add($"{username}:Interest={content}");
            }
            else
            {
                memory_stored.Add($"{username}:{type}={content}");
            }

            File.WriteAllLines(filepath, memory_stored);
        }


        public void DisplayUserInterests(string username)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("No memory file found.");
                return;
            }

            var lines = File.ReadAllLines(filepath);
            bool found = false;

            foreach (var line in lines)
            {
                if (line.StartsWith($"{username}:Interest="))
                {
                    string interest = line.Substring(line.IndexOf("=") + 1);
                    Console.WriteLine($"- {interest} is one of your interests");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No interests found for this user.");

            }
        }

       

        public void StoreInterest(string username, string interest)
        {
            File.AppendAllText(filepath, $"{username}:Interest={interest}{Environment.NewLine}");
        }



    }
}
