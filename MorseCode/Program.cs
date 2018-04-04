using System;
using System.Collections.Generic;
using System.IO; //ask Mark why this did not come in?
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var morseLibrary = new Dictionary<char, string>();

            const string libraryFilePath = "../../morse.csv";


            //The program should read the conversion data from a file and build a Dictionary in memory to help in the conversion (StreamReader)
            using (var readFile = new StreamReader(libraryFilePath))
            {
                while (readFile.Peek() > -1)
                {
                    var letterInfo = readFile.ReadLine().Split(',');
                    morseLibrary.Add(Convert.ToChar(letterInfo[0]), letterInfo[1]);
                    }
                }

                //The Program should ask user if they have another word convert, if yes, then repeat the process
                var programIsRunning = true;

                while (programIsRunning)
                {
                    //As a user, I should be able to type in a phrase to convert. This should include letters and numbers
                    Console.WriteLine("Let's translate some Morse Code! What would you like to translate?");
                    var response = Console.ReadLine();
                    var letters = response.ToUpper().ToCharArray();
                    var morseTranslation = "";


                //The Program should convert the text that the use typed in to Morse Code

                //break apart string into characters
                //for each character it should find and return that value (morse translation) should be stored and added to a new string
                foreach (var letter in letters)
                {
                    if (morseLibrary.ContainsKey(letter))
                    {
                        morseTranslation = morseTranslation + morseLibrary[letter];
                    } else
                    {
                        morseTranslation = morseTranslation + letter;
                    }
                    }
                    //The Program should display the converted text to the user
                    Console.WriteLine($"{morseTranslation}");
                    Console.WriteLine("Do you want to translate another word? (Yes) or (No)");
                    var command = Console.ReadLine();
                    if (command == "no")
                {
                    programIsRunning = false;
                }
            }
            }
        }
    }

//Adventure
//Save the User's past results and display them if the user asks. This should persist across multiple runnings of the app (read/write to a file)
//Allow the user to type in Morse Code and convert to English (need spaces between characters)