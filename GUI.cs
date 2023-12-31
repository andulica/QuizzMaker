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
            string question = string.Empty;

            // Keep looping until a non-empty question is received
            while (string.IsNullOrEmpty(question))
            {
                Console.WriteLine("Please enter your question: ");
                question = Console.ReadLine();
            }
            return question;
        }

        /// <summary>
        /// Takes the user's answer from the console and ensures that it is a valid integer within the specified range (1 to max).
        /// </summary>
        /// <returns>An integer representing the valid user answer.</returns>
        public static int GetUserChoiceIndex(int max)
        {
            Console.WriteLine($"Please choose an answer (1 to {max}):  ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userAnswerString = Console.ReadLine();

                // Attempt to parse the input string to an integer
                if (!int.TryParse(userAnswerString, out int userAnswerInt))
                {
                    Console.WriteLine("Please enter a number that corresponds to your displayed options: ");
                    continue;
                }

                // If the parsed integer is within the specified range, return it
                if (userAnswerInt >= 1 && userAnswerInt <= max)
                {
                    return userAnswerInt;
                }

                // Otherwise, notify the user that the input was out of range
                Console.WriteLine($"Please enter a number from 1 to {max}");
            }
        }

        /// <summary>
        /// Takes the user's answer from the console and ensures that it is a valid integer within the specified range (min to max).
        /// </summary>
        /// <returns>An integer representing the valid user answer.</returns>
        public static int GetUserChoiceIndex(int min, int max)
        {
            Console.WriteLine($"Please choose an answer ({min} to {max}):  ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userAnswerString = Console.ReadLine();

                // Attempt to parse the input string to an integer
                if (!int.TryParse(userAnswerString, out int userAnswerInt))
                {
                    Console.WriteLine("Please enter a number that corresponds to your displayed options: ");
                    continue;
                }

                // If the parsed integer is within the specified range, return it
                if (userAnswerInt >= min && userAnswerInt <= max)
                {
                    return userAnswerInt;
                }

                // Otherwise, notify the user that the input was out of range
                Console.WriteLine($"Please enter a number from {min} to {max}");
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
        /// Prompts the user to provide answers for a specific question. The method ensures that the user provides exactly 5 answers,
        /// and marks at least one of them as correct using an asterisk ('*').
        /// </summary>
        /// <returns>An array of answers, where correct answers are denoted with an asterisk at the start.</returns>
        public static string[] TakeUserAnswers()
        {
            string[] answers;
            Console.WriteLine("How many answers you want for this question? (3-5)");
            int numberOfAnswers = GetUserChoiceIndex(Constants.MIN_ANSWERS_PER_QUESTION, Constants.MAX_ANSWERS_PER_QUESTION);
            // Initialize the array to store the specified number of answers
            answers = new string[numberOfAnswers];
            int index = 0;

            // Notify the user about the required number of answers
            Console.WriteLine($"Please enter {numberOfAnswers} answers for this question: ");

            // Loop to collect all the answers from the user
            while (index < numberOfAnswers)
            {
                string answer = Console.ReadLine();

                // Ensure the user doesn't provide an empty or null answer
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Please enter a valid value.");
                }
                else
                {
                    // Confirm and store the answer provided by the user
                    Console.WriteLine($"Answer {index + 1} is: {answer}");
                    answers[index] = answer;
                    index++;
                }
            }

            string prompt = $"Do you want to mark more answers as correct? ({Constants.CHOICE_YES}/{Constants.CHOICE_NO}) ";
            bool finish = true;

            // Loop to allow the user to mark answers as correct
            while (finish)
            {
                Console.WriteLine("Please select the answer(s) to be marked as right answer(s): ");
                int correctAnswer = GetUserChoiceIndex(numberOfAnswers);

                // Check if the selected answer has already been marked as correct
                if (answers[correctAnswer - 1].Contains(Constants.CORRECT_ANSWER_MARKER))
                {
                    Console.WriteLine("This answer has been marked correct already.");
                }

                // Prefix the selected answer with an asterisk to mark it as correct
                answers[correctAnswer - 1] = answers[correctAnswer - 1].Insert(0, Constants.CORRECT_ANSWER_MARKER);

                // Ask the user if they want to mark more answers as correct
                finish = GetYesNo(prompt);
            }

            return answers;
        }

        /// <summary>
        /// Generates a list of questions for a quiz game.
        /// This method continuously prompts the user to create new questions with their corresponding answers, and to mark at least one correct answer.
        /// The user can choose to continue adding more questions or stop and return the created list of questions.
        /// </summary>
        /// <returns>Returns a list of questions for the game.</returns>
        public static List<Question> TakeQuestionsForQuiz()
        {
            List<Question> questions = new List<Question>();
            bool continueAdding;

            do
            {
                // Take a question from the user
                Question question = new Question();
                question.QuestionString = GUI.TakeUserQuestion();
                question.Answers = GUI.TakeUserAnswers();

                // Add the question to the list
                questions.Add(question);

                continueAdding = GetYesNo($"Do you want to add more questions? ({Constants.CHOICE_YES}/{Constants.CHOICE_NO})");

                // Continue adding questions as long as the user enters "Y"
            } while (continueAdding);

            return questions;
        }

        /// <summary>
        /// Displays a list of answers to the console, numbering each answer.
        /// </summary>
        /// <param name="answersList">A list of answers to be displayed.</param>
        private static void DisplayAnswers(string[] answersList)
        {
            for (int i = 0; i < answersList.Length; i++)
            {
                Console.WriteLine($"Answer {i + 1}. {answersList[i]}");
            }
        }

        /// <summary>
        /// Displays a welcome message for the Quiz Game. The method sets the console title, foreground color, and background color to stylize the welcome message.
        /// </summary>
        public static void DisplayWelcomeMessage()
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
            Console.Clear();
            Console.WriteLine("Welcome to our game. The rules for this game are as follows: " +
                "\n From the Main Menu, you have the possibility to create new games with as many questions as you want." +
                "\n For each question, you will be prompted to add a maximum of 5 answers." +
                "\n At least one of the answers must be marked with the sign '*' to indicate that it is one of the correct answers." +
                "\n The game supports multiple correct answers per question.");
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
                XMLFileOperations.Serialize(TakeQuestionsForQuiz());
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
        private static string[] RemoveAsterisksFromAnswers(string[] answersWithAsterisks)
        {
            // Create a new array to hold the answers without asterisks
            string[] answersWithoutAsterisks = new string[answersWithAsterisks.Length];

            for (int i = 0; i < answersWithAsterisks.Length; i++)
            {
                // For each answer, remove the asterisk (if present) by replacing it with an empty string
                answersWithoutAsterisks[i] = answersWithAsterisks[i].Replace(Constants.CORRECT_ANSWER_MARKER, string.Empty);
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
                        return XMLFileOperations.Deserialize(filePath);
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
        /// Prompts the user to select an XML file by name, ensuring that the chosen file exists and is not empty.
        /// </summary>
        /// <param name="basePath">The directory path where the XML files are located.</param>
        /// <returns>The full file path of the selected XML file.</returns>
        public static string SelectXmlFileAndFilePath(string basePath)
        {
            string nameForGame;

            // Continuously prompt the user until a valid, non-empty XML file is selected
            while (true)
            {
                nameForGame = TakeNameForFileFromUser();

                // Construct the full file path by combining the base directory path and the user-provided file name
                string filePath = Path.Combine(basePath, nameForGame + ".xml");

                // Check if the constructed file path corresponds to an existing file
                if (File.Exists(filePath))
                {
                    // Verify that the file is not empty (i.e., it contains data)
                    if (new FileInfo(filePath).Length > 0)
                    {
                        Console.Clear();
                        // Once a valid file has been selected, return its full path
                        return filePath;
                    }
                    else
                    {
                        Console.WriteLine("The selected file is empty. Please choose a different file.");
                    }
                }
                else
                {
                    Console.WriteLine("The specified file does not exist. Please enter a valid file name.");
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

        /// <summary>
        /// Displays a list of questions to the console, enumerating them with numbers.
        /// </summary>
        /// <param name="questions">The list of questions to display.</param>
        public static void DisplayQuestions(List<Question> questions)
        {
            Console.WriteLine("Questions are:");
            for (int i = 0; i < questions.Count; i++)
            {
                // Print each question with its corresponding number
                Console.WriteLine($"{i + 1}: {questions[i].QuestionString}");
            }
        }

        /// <summary>
        /// Allows the user to select a question from the provided list, edit it, and then update the list with the edited question.
        /// </summary>
        /// <param name="questionsToEdit">The list of questions that the user can choose to edit.</param>
        /// <returns>The updated list of questions, with the selected question edited.</returns>
        public static List<Question> EditQuestionsList(List<Question> questionsToEdit)
        {
            // Allow the user to select a question from the provided list
            Question questionToEdit = SelectQuestionFromList(questionsToEdit);

            // Edit the selected question (implementation details in the EditQuestion method)
            Question questionEdited = EditQuestion(questionToEdit);

            // Remove the original question from the list
            questionsToEdit.Remove(questionToEdit);

            // Add the edited question to the list
            questionsToEdit.Add(questionEdited);

            // Return the updated list of questions
            return questionsToEdit;
        }

        /// <summary>
        /// Prompts the user to select a question from the provided list by entering a number that corresponds to the question's position.
        /// </summary>
        /// <param name="questionsList">The list of questions from which the user can choose.</param>
        /// <returns>The selected question.</returns>
        private static Question SelectQuestionFromList(List<Question> questionsList)
        {
            Console.WriteLine($"Please choose a question: ");

            // Keep looping until a valid input is received
            while (true)
            {
                string userAnswerString = Console.ReadLine();

                // Attempt to parse the input string to an integer
                if (int.TryParse(userAnswerString, out int userAnswerInt))
                {
                    // If the parsed integer is within the specified range, return the corresponding question
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

        /// <summary>
        /// Provides options for the user to edit either the sentence or the answers of the specified question.
        /// Allows the user to continue editing until they choose to exit.
        /// </summary>
        /// <param name="questionToEdit">The question object that the user can edit.</param>
        /// <returns>The edited question object.</returns>
        private static Question EditQuestion(Question questionToEdit)
        {
            Console.WriteLine("Choose one of the following options: \n1. Edit question's sentence. \n2. Edit question's answers.");
            int userInput = GetUserChoiceIndex(2);
            bool exit;

            // Keep looping until the user decides to exit
            do
            {
                switch (userInput)
                {
                    case 1: // Edit the question's sentence
                        questionToEdit.QuestionString = EditQuestionSentence(questionToEdit);
                        Console.WriteLine("Question's sentence changed successfully!");
                        break;
                    case 2: // Edit the question's answers
                        questionToEdit.Answers = EditQuestionAnswers(questionToEdit);
                        Console.WriteLine("Question's answer(s) changed successfully!");
                        break;
                    default:
                        break;
                }

                // Ask the user if they want to continue editing or exit
                exit = GetYesNo($"Do you want to exit ? {Constants.CHOICE_YES}/{Constants.CHOICE_NO}");
            }
            while (!exit);

            // Return the edited question
            return questionToEdit;
        }

        /// <summary>
        /// Prompts the user to enter a new sentence for the specified question.
        /// </summary>
        /// <param name="question">The question object whose sentence the user will edit.</param>
        /// <returns>The new question sentence entered by the user.</returns>
        private static string EditQuestionSentence(Question question)
        {
            // Prompt the user for the new question sentence
            Console.WriteLine("Please enter the new question sentence: ");

            // Read the user's input
            string questionSentence = Console.ReadLine();

            // Return the new question sentence
            return questionSentence;
        }

        /// <summary>
        /// Allows the user to edit one or more answers of the specified question.
        /// The user is repeatedly prompted to edit answers until they choose not to continue.
        /// </summary>
        /// <param name="question">The question object whose answers the user will edit.</param>
        /// <returns>The array of edited answers.</returns>
        private static string[] EditQuestionAnswers(Question question)
        {
            // Prompt the user if they want to continue editing answers
            bool continueEditAnswers;

            do
            {
                // Display the current answers
                DisplayAnswers(question.Answers);

                // Take user input to select an answer to edit
                int userSelectedAnswer = GetUserChoiceIndex(question.Answers.Length);

                // Edit the selected answer (implementation details in the EditQuestionAnswer method)
                question.Answers[userSelectedAnswer] = EditQuestionAnswer();

                // Check again if the user wants to continue editing answers
                continueEditAnswers = GetYesNo($"Do you want to edit more answers? {Constants.CHOICE_YES}/{Constants.CHOICE_NO}");
            }
            while (continueEditAnswers);

            // Return the edited answers
            return question.Answers;
        }

        /// <summary>
        /// Prompts the user to enter a new answer to replace an existing answer.
        /// </summary>
        /// <returns>The new answer entered by the user.</returns>
        private static string EditQuestionAnswer()
        {
            // Prompt the user for the new answer
            Console.WriteLine("Please enter the new answer: ");

            // Read the user's input
            string newAnswer = Console.ReadLine();

            // Return the new answer
            return newAnswer;
        }

        /// <summary>
        /// Asks the user if they would like to repeat the quiz, accepting only 'Y' or 'N' as valid inputs.
        /// Continuously prompts the user until a valid response is entered.
        /// </summary>
        /// <returns>True if the user chooses 'Y', indicating they want to repeat the quiz; false if they choose 'N'.</returns>
        public static bool RepeatQuestions()
        {
            return GetYesNo("No more questions. Want to repeat the game?");
        }

        /// <summary>
        /// Prompts the user with the given message and expects a 'Y' (Yes) or 'N' (No) response.
        /// Loops until a valid response is received.
        /// </summary>
        /// <param name="prompt">The message to display to the user when prompting for input.</param>
        /// <returns>True if the user responds with 'Y', false if the user responds with 'N'.</returns>
        private static bool GetYesNo(string prompt)
        {
            char repeat;

            // Loop until a valid input (Y/N) is received
            while (true)
            {
                // Write the given prompt to the console
                Console.WriteLine(prompt);
                // Read the user's input, convert it to uppercase character
                repeat = char.ToUpper(Console.ReadKey().KeyChar);

                // If the input is 'Y' or 'N', break the loop
                if (repeat.Equals(Constants.CHOICE_NO) || repeat.Equals(Constants.CHOICE_YES))
                {
                    break;
                }

                // Notify the user to enter a valid input if received input is neither 'Y' nor 'N'
                Console.WriteLine($"Please enter one of the valid inputs ({Constants.CHOICE_YES}/{Constants.CHOICE_NO}).");
            }

            // Clear the console and return true for 'Y', false for 'N'
            Console.Clear();
            return repeat.Equals(Constants.CHOICE_YES);
        }

        /// <summary>
        /// Displays a thank you message to the user as they exit the game.
        /// This method is typically called when the user has chosen to end their session with the game.
        /// </summary>
        public static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for playing our game! See you next time!");
        }

        /// <summary>
        /// Deletes a quiz file specified by the provided FilePath, and updates the associated list of questions.
        /// The user is prompted for confirmation before deletion.
        /// </summary>
        /// <param name="result">A tuple containing the file path of the quiz to be deleted and the list of questions associated with it.</param>
        public static void DeleteQuiz(string filePath)
        {
            // Prompt the user to confirm if they really want to delete the specified file
            Console.WriteLine($"Are you sure that you want to delete {filePath} ?");
            // Call the GetYesNo method with the DELETE_MESSAGE constant to get the user's confirmation
            bool delete = GetYesNo(Constants.DELETE_MESSAGE);

            // If the user confirmed the deletion
            if (delete)
            {
                // Delete the specified file
                File.Delete(filePath);
                // Notify the user of the successful deletion
                DisplayReturnToMainMenu(Constants.FILES_DELETED_MESSAGE);
            }
            else
            {
                // If the user declined the deletion, notify them that the operation was cancelled
                DisplayReturnToMainMenu(Constants.DELETION_CANCELED_MESSAGE);
            }
        }

        /// <summary>
        /// Displays the user's score in the console.
        /// </summary>
        /// <param name="score">The number of questions the user answered correctly.</param>
        /// <param name="questions">The list of questions that were asked. The total number of questions is determined by the count of this list.</param>
        public static void DisplayScore(int score, List<Question> questions)
        {
            Console.WriteLine($"You have got {score} right out of {questions.Count}!");
        }

        /// <summary>
        /// Clears the console and displays a message indicating a return to the main menu.
        /// Then, pauses the execution for a short time to allow the user to read the message.
        /// </summary>
        /// <param name="messageToAdd">An additional message to display before the standard "Going back to Main menu..." text.</param>
        public static void DisplayReturnToMainMenu(string messageToAdd)
        {
            Console.Clear(); // Clears the console
            Console.WriteLine($"{messageToAdd} Going back to Main menu . . ."); // Prints the provided message along with the standard text
            Thread.Sleep(1000); // Pauses for 1 second (1000 milliseconds) to allow the user to read the message
        }
    }
}
