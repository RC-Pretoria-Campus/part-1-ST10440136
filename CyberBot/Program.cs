using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CyberBot
{
    class Program
    {
        //intialize the speech synthesizer for text-to-speech functionality
        static SpeechSynthesizer synth = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            //Configure the speech synthesizer with a teen female voice
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            synth.Volume = 100;//set the volume to max
            synth.Rate = 5;//set speak rate to 5

            //Starts the voice greeting in sync witht the rest of the code 
            Task.Run(() => synth.Speak($"Hello user,! Welcome to the cyber security awareness bot. Your doorway into online safety"));




            ShowAsciiHeader(); // Displays the ASCII header logo

            //prompts the user for their name and stores it
            string name = PromptForName();




            Console.WriteLine("Type 'exit' , 'quit' or 'close' to exit the application.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            //Display a personalized greeting message with border styling
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("******************************************************************************** ");
            Console.WriteLine($"*     Hello  {name} ,Tell me .How can I assist you today?   *");
            Console.WriteLine("********************************************************************************** ");
            Console.WriteLine(" ");
            Console.ResetColor();


            // Dictionary containing predefined responses for different user inputs
            var Response = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    { "how are you", "My software is doing well, so I am doing well. How may I be of assistance today?" },
    { "hello", "Hello! How can I be of assistance today?" },
    { "greeting", "Greetings! I am here to help you with your cybersecurity needs. Ask away!" },
    { "password", "Create a password that has a mixture of letters, numbers, and symbols. Ensure that the password is at least 8 characters long." },
    { "purpose", "I am a cybersecurity bot designed to help you stay safe online. I help with topics such as:\n1. Phishing\n2. Online safety\n3. Safe browsing.\nI educate you a bit on these topics and give you possible hints and guides to stay safe and avoid them." },
    { "questions", "You can ask me about phishing, online safety, safe browsing, and how to stay away from cyber threats." },
    { "ask about", "You can ask me about a variety of cybersecurity topics including phishing, passwords, online safety, safe browsing, and cyber threats." },
    { "why were you created", "I was designed to help users stay safe online by providing information on cybersecurity topics such as phishing, passwords, and secure browsing." },
    { "what is your function", "My function is to educate users on cybersecurity, answer questions about online threats, and provide safety tips for secure browsing." },
    { "phishing", "Phishing is a scam in which a victim is tricked into sharing sensitive information or downloading ransomware. Scammers will impersonate someone trustworthy, such as Amazon, a police department, or an employer, and tell you about a problem that requires immediate attention. In most cases, they will tell you that this problem can be solved using your credit card details, opening a malicious file, or typing your login data into a fraudulent or fake website.\n\nHere’s how you can avoid a phishing scam:\n1. Scrutinize every email or SMS message that hits your inbox. If someone sends you a URL or a file, don't open it unless you can verify the source. Contact the organization or person who supposedly wrote that email to verify its authenticity.\n2. Never send sensitive information like your social security number or credit card info via email or text. Your bank or the IRS will never ask for such information over unsecured platforms." },
    { "stay safe", "Here are some tips to stay safe online:\n1. Don’t share your personal information.\n2. Double-check any links before you click.\n3. Use secure public Wi-Fi networks.\n4. Use a VPN with your Wi-Fi connection.\n5. Only log into sites that start with https://.\n6. Be careful who you and your children talk to.\n7. Turn your Bluetooth off.\n8. Use antivirus and antimalware software." },
    { "safe browsing", "Here are some tips for safe browsing:\n1. Use a safe browser.\n2. Avoid clicking on search ads.\n3. Be cautious of 'Allow Notifications' pop-ups.\n4. Skip saving sensitive data.\n5. Scan links before downloading.\n6. Expand links before visiting them.\n7. Avoid websites that spam you with ads.\n8. Use private browsing.\n9. Perform a deep clean to regain control of your devices.\n10. Optimize your home network.\n11. Keep your devices updated.\n12. Run malware scans.\n13. Optimize your web browser for security and speed.\n14. Use a VPN for ad-blocking and secure, encrypted connections." },
    { "cyber threats", "A cyber attack is a deliberate exploitation of your systems and/or network. Cyber attacks use malicious code to compromise your computer, steal or leak your data, or hold your data hostage. Cyber attack prevention is essential for every business and organization.\n\nHere are some tips for prevention:\n1. Keep your software and systems fully up-to-date.\n2. Ensure endpoint protection, protecting networks that are remotely bridged to devices.\n3. Put your networks behind a firewall.\n4. Control access to your systems and always back up your data." }
};









            while (true)
            {
                //prompts user for input
                Console.Write($"{name}: ");
                string userInput = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine();//adds an open line after the users input for readability and visisbility
                
                //ensures that the userInput is not empty
                if (string.IsNullOrEmpty(userInput))
                {
                   TimelyResponse("CYBER: I didn't quite understand that could you rephrase.");
                    continue;
                }
                

                ///Handles the user saying thank you or okay
                if (userInput.Contains("Thank You") || userInput.Contains("Okay") || userInput.Contains("Ok"))
                {
                    TimelyResponse($" Will that be all? (yes/no)");
                    Console.Write($"{name}: ");
                    string confirmation = Console.ReadLine()?.Trim().ToLower();

                    if (confirmation == "yes")
                    {
                        TimelyResponse($"Goodbye {name}  ,Remember to keep safe online. ");
                        break;
                    }
                    else
                    {
                        TimelyResponse($"CYBER:Iam still here {name}, ask away! ");
                    }
}
                //checks for exit input
                if (userInput?.ToLower() == "exit" || userInput?.ToLower() == "quit" || userInput.ToLower() == "close")
                {
                    TimelyResponse($" Goodbye {name} :-) ,remeber to keep safe online!!! ");
                    break;
                }

                //searches for the response in the dictionary
bool foundResponse = false;
foreach (var entry in Response)
{
    if (userInput.Contains(entry.Key))
    {
        TimelyResponse($"CYBER: {entry.Value}");
        foundResponse = true;
        break;
    }
}
//if no response was found ,it provides a default response
if (!foundResponse)
{
    TimelyResponse("CYBER: Sorry, I don't understand that question. Try asking about phishing, online safety, or safe browsing,or passwords.");
                }


            }
        }

            //method to prompt user for their name
        private static string PromptForName()
        {
            Console.Write("Welcome to CyberBot! Please enter your username: ");
            return Console.ReadLine();
        }


      //method to diplay the ASCII Header with cyber security theme an in a darkCyan color
        private static void ShowAsciiHeader()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string asciiArt = @"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗ ██████╗  ██████╗ ████████╗
 ██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔═══██╗╚══██╔══╝
 ██║     ██║   ██║██████╔╝█████╗  ██████╔╝██████╔╝██║   ██║   ██║   
 ██║     ██║   ██║██╔══██╗██╔══╝  ██╔══██╗██╔═══╝ ██║   ██║   ██║   
 ╚██████╗╚██████╔╝██████╔╝███████╗██║  ██║██║     ╚██████╔╝   ██║   
  ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝      ╚═════╝    ╚═╝   
"
            ;
            Console.WriteLine("********************************************************************************************************************************************************");

            Console.WriteLine(asciiArt);
            Console.WriteLine("********************************************************************************************************************************************************");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWELCOME TO THE CYBERBOT\nPREPARING CONTENT...");
            Thread.Sleep(2000);

            Console.ResetColor();
        }


        //method to provide a bot response with a delayed effect 
        private static void TimelyResponse(string reply)//speak response asynchronously
        {
            //speak the response as it is being typed int the console
            Task.Run(() => SpeakResponse(reply));

            //chang the color for the bots response
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char c in reply)
            {
                Console.Write(c);
                Thread.Sleep(10);//time dely for a more realistic feel

            }
           

            Console.ResetColor();
            Console.WriteLine();//move to the next line 
            Console.WriteLine();//Adds  an extra blank lne for space in between 
            
                
           
        }
        //method to make the bot speak response aloud 
       private static void SpeakResponse(string message)
        {
            synth.SpeakAsync(message);
      }

        
      
    }
}





