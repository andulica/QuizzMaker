using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMakerProgram
{
    public class GUI
    {
        public static string TakeUserQuestion ()
        {
            string question = "";
            while (string.IsNullOrEmpty(question))
            {
                question = Console.ReadLine();
                Console.WriteLine($"question is: ' {question} '");            
            }
            return question;
        }

        public static List<string> TakeUserAnswers ()
        {
            List<string> answers = new List<string> ();
            string answer;
            while (answers.Count < 5)
            {
                Console.WriteLine("Please enter your answer to the question. Mark the correct answer(s) with the symbol '*' : ");
                answer = Console.ReadLine();

                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Please enter a valid value.");
                } 
                else
                {
                    answers.Add(answer);
                }
            }
            return answers;
        }

        public static void DisplayAnswers (List <string> answersList)
        {
            for(int i =0; i < answersList.Count; i++)
            {
                Console.WriteLine($"Answer {i}. {answersList[i]}");
            }
        }

        public static void WelcomeMessage()
        {
            Console.Title = ("Quiz Game");
            // Change the text color to green.
            Console.ForegroundColor = ConsoleColor.Green;

            // Change the background color to black.
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                  Welcome to the Ultimate QuizGame");
            // Reset the console colors to their defaults after you're done.
            Console.ResetColor();
        }
        public static void DisplayGameRules ()
        {
            Console.WriteLine("Welcome the our game. The rules for this game are as follows: " +
                "\n From the Main Menu you have the possibility to create new games with as many questions as you want" +
                "\n For each question you will be prompted to add a maximum of 5 answers." +
                "\n At least one of the answers must be marked with the sign '*' to indicate that is one of the correct answers." +
                "\n The game supports multiple correct answers per question.");
        }

        public static void DisplayCredits()
        {

        }

        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("MENU: ");
            Console.WriteLine("-------");
            Console.WriteLine("1. Select a quiz game from the list.");
            Console.WriteLine("2. Create a new quiz.");
            Console.WriteLine("3. Delete a specific quiz.");
            Console.WriteLine("4. Edit a specific quiz.");
            Console.WriteLine("5. Display game rules");
            Console.WriteLine("6. Exit");

        }

        public static void Divider ()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("       ########################");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public static string GetNameForFile ()
        {
            var path = "";
            string nameForGame = "";
            while (string.IsNullOrEmpty(nameForGame))
            {
                Console.WriteLine("Please enter a name for your file: ");
                nameForGame = Console.ReadLine();
                if (path.Equals($@"C:\temp\{nameForGame}.xml"))
                {
                    Console.WriteLine("This name is already in use. please enter a new name");
                }
              
            }
            return nameForGame;
        }
        

     

      
    }
}
