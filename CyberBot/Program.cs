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


            //Dictionary containing predefined response for different userInputs
            var Response = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                

                { "how are you", "My software is doing well, so I am doing well. How may I be of assistance today?" },

                { "hello", $"Hello {name}, How can I be of assistance today?" },

                { "password", "Create a password that has a mixture of letters, numbers, and symbols. Ensure that the password is at least 8 characters long." },

                { "purpose", "Iam a cyber security bot designed to help you keep safe online\nI help with topics such  as\n1.Phishsing\n2.Online safety\n3.Safe Browsing.\n I educate you a bit on these topics and give you possible hints and guides as to how to stay safe and avoid them" },

                { "questions", "You can ask me about phishing, online safety, safe browsing, and how to stay away from cyber threats." },

                { "phishing", "A scam in which a victim is tricked into sharing sensitive information or downloading ransomware\nscammers will impersonate someone trustworthy, such as Amazon, a police department, or an employer, and tell you about a problem that requires immediate attention\nIn most cases they will tell you that this problem can be solved using your credit card details, opening a malicious file or typing your login data into a fraudulent / fake website.Thsi is how you can avoid a phishsing scam\nScrutinize every email or SMS message that hits your inbox. If someone sends you a URL or a file, don't open it unless you can verify the source. And I'm not just telling you to look at the sender's email address or phone number. Try to contact the organization or person who supposedly wrote that email to verify its authenticity\nTo be clear, there are some things you should never send through an email or text message. If someone asks you to type out your social security number or credit card info in an email or text, ignore them! Your bank won't ask for this stuff on such an insecure platform, and neither will the IRS." },

                { "stay safe", "Don’t share your personal information\n2. Double-check any links before you click\n3. Use secure public Wi-Fi networks\n4. Use a VPN with your Wi-Fi connection\n5. Only log into sites that start with https://\n6. Be careful who you and your children talk to\n7. Turn your Bluetooth off\n8. Use antivirus and antimalware software" },

                { "safe browsing", "Use a safe browser\nAvoid clicking on search ads\nBe cautious of 'Allow Notifications' pop - ups\nSkip saving sensitive data\nScan links before downloading\nExpand links before visiting them\nAvoid websites that spam you with ads.\r\nUse private browsing\nPerform a deep clean and regain control of your devices\nOptimize your home network\nKeep your devices updated\nRun malware scans\nOptimize your web browser for security and speed\nUse a VPN for ad-blocking and secure, encrypted connections." },

                { "cyber threats", "A cyber attack is a deliberate exploitation of your systems and/or network. Cyber attacks use malicious code to compromise your computer, logic or data and steal, leak or hold your data hostage. Cyber attack prevention is essential for every business and organisation\nKepp your software and systems fully up to date\nEnsure end point protection ,protecting networks that are remotely bridged to devices.\nPut your networks behind a firewall\nControl access to your systems and always backup your data." },


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
                if (userInput.Contains("Thank You") || userInput.Contains("Okay"))
                {
                    TimelyResponse($"CYBER: Your wecome,{name}. Will that be all? (yes/no)");
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





