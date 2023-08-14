﻿namespace QuizMakerProgram
{
    public class GUI
    {
        /// <summary>
        /// Takes a question from the user through the console and ensures that it is a non-empty string.
        /// </summary>
        /// <returns>A string representing the user's question.</returns>
        public static string TakeUserQuestion()
        {          
            string question = "";

            // Keep looping until a non-empty question is received
            while (string.IsNullOrEmpty(question))
            {               
                Console.WriteLine("Please enter your question: ");
                question = Console.ReadLine();
            }    
            return question;
        }

        /// <summary>
        /// Takes the user input from the console and ensures that it is a valid integer within the specified range.
        /// </summary>
        /// <returns>An integer representing the valid user input.</returns>
        public static int TakeUserInput(int min, int max)
        {
            Console.WriteLine($"Please choose one of the options ({min} to {max}): ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userInputString = Console.ReadLine();

                // Attempt to parse the input string to an integer
                if (int.TryParse(userInputString, out int userInputInt))
                {
                    // If the parsed integer is within the specified range, return it
                    if (userInputInt >= min && userInputInt <= max)
                    {
                        return userInputInt;
                    }
                    else // Otherwise, notify the user that the input was out of range
                    {
                        Console.WriteLine($"Please enter a number from {min} to {max}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number that corresponds to the listed options: ");
                }
            }
        }

        /// <summary>
        /// Takes the user's answer from the console and ensures that it is a valid integer within the specified range (1 to 5).
        /// </summary>
        /// <returns>An integer representing the valid user answer.</returns>
        public static int TakeUserInput(int max)
        {
            Console.WriteLine($"Please choose an answer (1 to {max}):  ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userAnswerString = Console.ReadLine();

                // Attempt to parse the input string to an integer
                if (int.TryParse(userAnswerString, out int userAnswerInt))
                {
                    // If the parsed integer is within the specified range, return it
                    if (userAnswerInt >= 1 && userAnswerInt <= max)
                    {
                        return userAnswerInt;
                    }
                    else // Otherwise, notify the user that the input was out of range
                    {
                        Console.WriteLine($"Please enter a number from 1 to {max}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number that corresponds to your displayed options: ");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a name for a file and retrieves the input as a string.
        /// </summary>
        /// <returns>A string representing the name entered by the user for the file.</returns>
        public static string TakeNameForFileFromUser()
        {
            Console.WriteLine("Please enter a name for your file: ");

            string nameForFile = Console.ReadLine();

            return nameForFile;
        }

        /// <summary>
        /// Takes answers for a specific question from the user. The method ensures that exactly 5 answers are introduced,
        /// and at least one correct answer is marked with an asterisk symbol ('*').
        /// </summary>
        /// <returns>An array of answers, where correct answers are denoted with an asterisk.</returns>
        public static string[] TakeUserAnswers()
        {
            string[] answers;

            // Continue the loop until at least one answer is marked as correct
            do
            {
                // Initialize the array with the specified number of answers
                answers = new string[Constants.MAX_ANSWERS_PER_QUESTION];
                int index = 0;

                Console.WriteLine($"Please enter {Constants.MAX_ANSWERS_PER_QUESTION} answers for this question. Mark the correct answer(s) with the symbol '*': ");

                // Loop to take 5 answers from the user
                while (index < Constants.MAX_ANSWERS_PER_QUESTION)
                {
                    string answer = Console.ReadLine();

                    // Check if the answer is not empty or null
                    if (string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine("Please enter a valid value.");
                    }
                    else
                    {
                        // Display the answer and store it in the array
                        Console.WriteLine($"Answer {index + 1} is: {answer}");
                        answers[index] = answer;
                        index++;
                    }
                }

                // Check if any of the answers have been marked as correct
                if (!answers.Any(a => a.Contains('*')))
                {
                    Console.WriteLine("Error: No answer has been marked as correct. Ensure you mark at least one correct answer with '*'. Please re-enter the answers.");
                }

            } while (!answers.Any(a => a.Contains('*'))); // Repeat the loop if no correct answers are provided

            return answers;
        }
        public static void SelectQuizToPlay()
        {
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);
            List<Question> questionsToPlay = GUI.SelectXmlFile(Constants.BASE_PATH);
        }

        /// <summary>
        /// Displays a list of answers to the console, numbering each answer.
        /// </summary>
        /// <param name="answersList">A list of answers to be displayed.</param>
        public static void DisplayAnswers(string [] answersList)
        {
            for (int i = 0; i < answersList.Length; i++)
            {
                Console.WriteLine($"Answer {i}. {answersList[i]}");
            }
        }

        /// <summary>
        /// Displays a welcome message for the Quiz Game. The method sets the console title, foreground color, and background color to stylize the welcome message.
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.Title = "Quiz Game";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                  Welcome to the Ultimate QuizGame");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the game rules for the user, outlining the process of creating new games, adding questions and answers, and marking correct answers.
        /// </summary>
        public static void DisplayGameRules()
        {
            Console.WriteLine("Welcome to our game. The rules for this game are as follows: " +
                "\n From the Main Menu, you have the possibility to create new games with as many questions as you want." +
                "\n For each question, you will be prompted to add a maximum of 5 answers." +
                "\n At least one of the answers must be marked with the sign '*' to indicate that it is one of the correct answers." +
                "\n The game supports multiple correct answers per question.");
        }

        /// <summary>
        /// Displays the total credits available to the user or participant in the game.
        /// </summary>
        /// <param name="credits">The total number of credits to be displayed.</param>
        public static void DisplayCredits(int credits)
        {
            Console.WriteLine($"Total credits are {credits} ");
        }

        /// <summary>
        /// Displays the main menu for the quiz game. The menu provides options to select, create, delete, or edit a quiz,
        /// view game rules, and exit the application.
        /// </summary>
        public static void DisplayMenu()
        {
            // Set the text color to dark blue for the menu
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("MENU: ");
            Console.WriteLine("-------");

            // Print the menu options
            Console.WriteLine("1. Select a quiz game from the list.");
            Console.WriteLine("2. Create a new quiz.");
            Console.WriteLine("3. Delete a specific quiz.");
            Console.WriteLine("4. Edit a specific quiz.");
            Console.WriteLine("5. Display game rules");
            Console.WriteLine("6. Exit");
        }

        /// <summary>
        /// Displays a visual divider in the console with specific foreground and background colors.
        /// The divider consists of a series of hash ('#') symbols, and it's surrounded by empty lines for visual separation.
        /// </summary>
        public static void DisplayDivider()
        {
            // Set the text color to yellow and the background color to black
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("       ########################");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a list of all XML files located in a specific directory (C:\temp\).
        /// If no files are found, it prompts the user to create a new file and add questions to it.
        /// </summary>
        public static void DisplayAllXmlFiles(string basePath)
        {
            Console.Clear();

            // Get all XML files in the specified directory
            string[] files = Directory.GetFiles(basePath, "*.xml");

            // Check if no files are found
            if (files.Length == 0)
            {
                // Print a message indicating no files found and prompt the user to create a new file
                Console.WriteLine("No files found in the directory. Please create a new file and add questions.");

                // Serialize a new quiz file with the user-defined name and generated questions
                Quiz.Serialization(QuizLogic.GenerateQuestionsForGame());
            }

            Console.WriteLine("Files available:");

            // Iterate through the files and print the file names without extensions
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                Console.WriteLine(fileName);
            }
        }


        /// <summary>
        /// Removes asterisks (*) from an array of answers.
        /// This method can be used to transform an array of answers where correct answers are marked with an asterisk into an array suitable for display to the player.
        /// </summary>
        /// <param name="answersWithAsterisks">An array of answers where correct answers are marked with an asterisk (*).</param>
        /// <returns>Returns a new array with the same answers but without asterisks.</returns>
        public static string[] RemoveAsterisksFromAnswers(string[] answersWithAsterisks)
        {
            // Create a new array to hold the answers without asterisks
            string[] answersWithoutAsterisks = new string[answersWithAsterisks.Length];

            for (int i = 0; i < answersWithAsterisks.Length; i++)
            {
                // For each answer, remove the asterisk (if present) by replacing it with an empty string
                answersWithoutAsterisks[i] = answersWithAsterisks[i].Replace("*", "");
            }

            return answersWithoutAsterisks;
        }

        /// <summary>
        /// Prompts the user to enter the name of an XML file located in a specific directory (C:\temp\),
        /// then deserializes and returns a list of questions from the selected file.
        /// The method continues to prompt the user until a valid, non-empty XML file is provided.
        /// </summary>
        /// <returns>A list of questions deserialized from the chosen XML file.</returns>
        public static List<Question> SelectXmlFile(string basePath)
        {
            string nameForGame;

            // Loop indefinitely until a valid, non-empty XML file is selected
            while (true)
            {
                nameForGame = TakeNameForFileFromUser();

                // Combine the base path and user-provided name to form the full file path
                string filePath = Path.Combine(basePath, nameForGame + ".xml");

                if (File.Exists(filePath))
                {
                    // Check if the file is not empty (contains at least 1 question)
                    if (new FileInfo(filePath).Length > 0)
                    {
                        Console.Clear();
                        // Deserialize the questions from the file and return them
                        return Quiz.Deserialize(filePath);
                    }
                    else
                    {
                        Console.WriteLine("The file is empty. Please choose another file.");
                    }
                }
                else
                {
                    Console.WriteLine("This file does not exist. Please try again.");
                }
            }
        }

        public static (string FilePath, List<Question> Questions) SelectXmlFileAndFilePath(string basePath)
        {
            string nameForGame;

            // Loop indefinitely until a valid, non-empty XML file is selected
            while (true)
            {
                nameForGame = TakeNameForFileFromUser();

                // Combine the base path and user-provided name to form the full file path
                string filePath = Path.Combine(basePath, nameForGame + ".xml");

                if (File.Exists(filePath))
                {
                    // Check if the file is not empty (contains at least 1 question)
                    if (new FileInfo(filePath).Length > 0)
                    {
                        Console.Clear();
                        // Deserialize the questions from the file and return them
                        return (filePath, Quiz.Deserialize(filePath));
                    }
                    else
                    {
                        Console.WriteLine("The file is empty. Please choose another file.");
                    }
                }
                else
                {
                    Console.WriteLine("This file does not exist. Please try again.");
                }
            }
        }


        /// <summary>
        /// Displays a specified question along with its answers to the console.
        /// The answers are presented without asterisks, even if they were originally marked with them to indicate correctness.
        /// </summary>
        /// <param name="question">The question object containing the question string and its associated answers.</param>
        public static void DisplayQuestionItsAnswers(Question question)
        {
            // Remove the asterisks from the answers, as they may be used to mark correct answers
            string[] answersWithoutStar = GUI.RemoveAsterisksFromAnswers(question.Answers);

            Console.WriteLine($"Question is '{question.QuestionString}' and the answers are: ");

            // Loop through the answers and print each one, numbering them for clarity
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine($" {i + 1}: {answersWithoutStar[i]} ");
            }
        }

        public static void DisplayQuestions (List <Question> questions)
        {
            Console.WriteLine("Questions are:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {questions[i].QuestionString}");
            }
        }

        public static List<Question> EditQuestionsList (List <Question> questionsToEdit)
        {
            Question questionToEdit = SelectQuestionFromList(questionsToEdit);
            Question questionEdited = EditQuestion(questionToEdit);
            questionsToEdit.Remove(questionToEdit);
            questionsToEdit.Add(questionEdited);
            return questionsToEdit;
            
        }

        public static Question SelectQuestionFromList (List <Question> questionsList)
        {
            Console.WriteLine($"Please choose an question:  ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userAnswerString = Console.ReadLine();
                 
                // Attempt to parse the input string to an integer
                if (int.TryParse(userAnswerString, out int userAnswerInt))
                {
                    // If the parsed integer is within the specified range, return it
                    if (userAnswerInt >= 1 && userAnswerInt <= questionsList.Count)
                    {
                        return questionsList[userAnswerInt - 1];
                    }
                    else // Otherwise, notify the user that the input was out of range
                    {
                        Console.WriteLine($"Please enter a number from 1 to {questionsList.Count}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number that corresponds to your displayed options: ");
                }
            }
        }
        public static Question EditQuestion (Question questionToEdit)
        {
            Console.WriteLine("Choose one of the following options: \n1. Edit question's sentence. \n2. Edit question's answers.");
            int userInput = TakeUserInput(2);
            bool exit;
            do
            {
                switch (userInput)
                {
                    case 1:
                        questionToEdit.QuestionString = EditQuestionSentence(questionToEdit);
                        Console.WriteLine("Questions sentence changed successfully!");
                        break;
                    case 2:
                        questionToEdit.Answers = EditQuestionAnswers(questionToEdit);
                        Console.WriteLine("Questions answer(s) changed successfully!");
                        break;
                    default:
                        break;
                }
                exit = GetYesNo();
            }
            while (!exit);

            return questionToEdit;
        }

        public static string EditQuestionSentence (Question question)
        {
            Console.WriteLine("Please enter the new question sentence: ");
            string questionSentence = Console.ReadLine();

            return questionSentence;
        }

        public static string[] EditQuestionAnswers (Question question)
        {
            string repeatMessage = "Do you want edit more answers? ";
            bool continueEditAnswers = GetYesNo(repeatMessage);
            do
            {
                DisplayAnswers(question.Answers);
                int userSelectedAnswer = TakeUserInput(question.Answers.Length);

                question.Answers[userSelectedAnswer] = EditQuestionAnswer();

            }
            while (continueEditAnswers);

            return question.Answers;
        }

        public static string EditQuestionAnswer ()
        {
            Console.WriteLine("Please enter the new answer: ");
            string newAnswer = Console.ReadLine();

            return newAnswer;
        }


        /// <summary>
        /// Asks the user if they would like to repeat the quiz, accepting only 'Y' or 'N' as valid inputs.
        /// Continuously prompts the user until a valid response is entered.
        /// </summary>
        /// <returns>True if the user chooses 'Y', indicating they want to repeat the quiz; false if they choose 'N'.</returns>
        public static bool RepeatQuestions()
        {
            return GetYesNo("Want to repeat the game?");
        }



        private static bool GetYesNo(string prompt)
        {
            char repeat;

            // Loop until a valid input (Y/N) is received
            while (true)
            {
                Console.WriteLine(prompt);
                repeat = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                // Break the loop if a valid input is received
                if (repeat.Equals('N') || repeat.Equals('Y'))
                {
                    break;
                }

                Console.WriteLine("Please enter one of the valid inputs (Y/N).");
            }


            if (repeat.Equals('Y'))
            {
                Console.Clear();
                return true;
            }
            Console.Clear();
            return false;
        }

        private static bool GetYesNo()
        {
            char repeat;
            Console.WriteLine("Do you want to exit? ");
            // Loop until a valid input (Y/N) is received
            while (true)
            {
                repeat = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                // Break the loop if a valid input is received
                if (repeat.Equals('N') || repeat.Equals('Y'))
                {
                    break;
                }

                Console.WriteLine("Please enter one of the valid inputs (Y/N).");
            }


            if (repeat.Equals('Y'))
            {
                Console.Clear();
                return true;
            }
            Console.Clear();
            return false;
        }

        /// <summary>
        /// Displays a thank you message to the user as they exit the game.
        /// This method is typically called when the user has chosen to end their session with the game.
        /// </summary>
        public static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for playing our game! See you next time!");
        }
    }
}
