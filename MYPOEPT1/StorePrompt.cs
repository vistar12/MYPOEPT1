using System;
using System.Collections;

namespace MYPOEPT1
{
    public class StorePrompt
    {
        // Lists to store bot responses, ignored words, and exit words
        private  ArrayList botResponses = new ArrayList();
        private ArrayList wordsToIgnore = new ArrayList();
        private ArrayList exitWords = new ArrayList();

        // A constructor  that initializes the bot and starts the interaction

        public StorePrompt()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Welcome to the Vistar  cyber Security Bot:");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            RunBot();
        }

        // This method  stores predifined bot responses that are related to cybersecurity
        public void StoreBotResponses()
        {
            botResponses.Add("firewall|protection:Firewalls are essential for blocking unauthorized access to your network.");
            botResponses.Add("phishing|email:Phishing emails often try to trick you into revealing sensitive information. Always verify the sender!");
            botResponses.Add("malware|virus:Malware, like viruses, can compromise your system. Regular updates and antivirus tools can help.");
            botResponses.Add("encryption|data:Encryption ensures that your data is securely stored and transmitted.");
            botResponses.Add("authentication|passwords:Strong authentication methods, like two-factor authentication, improve account security.");
            botResponses.Add("hacker|attack:Hackers may exploit vulnerabilities. Regularly updating software is vital.");
            botResponses.Add("ransomware|payment:Ransomware locks your data and demands payment. Backup your data regularly to mitigate this risk.");
            botResponses.Add("VPN|privacy:Using a VPN enhances privacy by encrypting your internet connection.");
            botResponses.Add("cyberattack|breach:A cyberattack can expose sensitive information. Preparedness is key to minimizing damage.");
            botResponses.Add("antivirus|scan:Antivirus software can detect and remove malicious files. Run scans regularly.");
            botResponses.Add("update|patch:Keeping your software updated prevents attackers from exploiting known vulnerabilities.");
            botResponses.Add("backup|recovery:Regular backups can save you from losing important files during an attack.");
            botResponses.Add("social engineering|scam:Social engineering tricks people into revealing private information. Always stay vigilant.");
            botResponses.Add("credentials|login:Protect your credentials by using strong, unique passwords for each account.");
            botResponses.Add("incident|response:An incident response plan ensures that cybersecurity breaches are handled effectively.");
            botResponses.Add("network|security:Securing your network involves firewalls, encryption, and regular monitoring for anomalies.");
            botResponses.Add("spyware|monitoring:Spyware can secretly monitor your activities. Use anti-spyware tools to protect yourself.");
            botResponses.Add("cookies|tracking:Cookies can track your online activities. Clear them regularly to enhance privacy.");
            botResponses.Add("password|pin: A password is a secret string of characters (letters, numbers, and symbols) used to verify a user's identity and grant access to systems, applications, or services..");
            botResponses.Add("vulnerability|exploit:Attackers look for vulnerabilities in software to exploit. Security patches fix these gaps.");
            botResponses.Add("threat|risk:Identifying and mitigating potential threats helps reduce cybersecurity risks.");
            botResponses.Add("cybersecurity|awareness:Staying informed about cybersecurity is the first step to staying protected.");

        }

        //This method stores common words to ignore ( for example , articles and conjunctions
        public void StoreWordsToIgnore()
        {
            wordsToIgnore.Add("a");
            wordsToIgnore.Add("an");
            wordsToIgnore.Add("the");
            wordsToIgnore.Add("is");
            wordsToIgnore.Add("are");
            wordsToIgnore.Add("to");
            wordsToIgnore.Add("of");
            wordsToIgnore.Add("and");
        }


        public void StoreExitWords()
        {
            exitWords.Add("exit");
            exitWords.Add("quit");
            exitWords.Add("bye");
            exitWords.Add("stop");
        }
        //This method is to validate user input to ensure its not empty or null
        public Boolean CheckInput(string user_input)
        {
            if (string.IsNullOrEmpty(user_input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Artificial Intelligence: Name is null,please enter a  proper name");
                Console.ResetColor();

                return false;
            }


            return true;

        }
        // This is the main chatbot interaction loop
        public void RunBot()
        {
            StoreBotResponses();
            StoreWordsToIgnore();
            StoreExitWords();

            bool running = true;

            //Ask for users name and validate input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Artificial Intelligence: Welcome to the  AI Bot, may i  get your name");
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("User;");
                name = Console.ReadLine();
            } while (!CheckInput(name));

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Artificial Intelligence: Please ask your question or type an exit word to leave.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(name + ":");
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


                bool matchFound = false;
                foreach (string response in botResponses)
                {


                    string[] parts = response.Split(':');
                    string triggers = parts[0];
                    string botReply = parts[1];


                    string[] triggerWords = triggers.Split('|');
                    foreach (string trigger in triggerWords)
                    {
                        if (userInput.Contains(trigger))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Artificial Intelligence: {botReply}");
                            matchFound = true;
                            break;
                        }
                    }

                    if (matchFound) break;
                }
                //  if there is no keyword match found ,it informs the user
                if (!matchFound)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Artificial Intelligence: Sorry, I do not have a response for your question.");
                }
            }
        }
    }
}