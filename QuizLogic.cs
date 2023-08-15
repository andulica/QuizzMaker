using System.Xml.Serialization;

namespace QuizMakerProgram
{
    public class QuizLogic
    {
        public XmlSerializer writer = new XmlSerializer(typeof(List<Question>));

        /// <summary>
        /// Evaluates a player's answer to a quiz question.
        /// The method takes in the correct answers (marked with an asterisk) and repeatedly prompts the player to select an answer until a correct one is chosen.
        /// </summary>
        /// <param name="answersWithAsterisks">An array of answers with correct ones marked by an asterisk (*).</param>
        /// <returns>Returns 'true' if the player's answer is correct.</returns>
        public static bool EvaluatePlayerAnswer(string[] answersWithAsterisks, int answer)
        {
            bool correct = false;

            // Keep prompting the player for an answer until a correct one is chosen
            while (!correct)
            {
                // Check if the selected answer is marked with an asterisk in the original array
                if (answersWithAsterisks[answer - 1].Contains('*'))
                {
                    Console.WriteLine("Correct!");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Incorrect... Better luck next time.");
                    break;
                }
            }
            // Return the result of the evaluation (always true, as the loop ensures a correct answer)
            return correct;
        }

        /// <summary>
        /// Generates a list of questions for a quiz game.
        /// This method continuously prompts the user to create new questions with their corresponding answers, and to mark at least one correct answer.
        /// The user can choose to continue adding more questions or stop and return the created list of questions.
        /// </summary>
        /// <returns>Returns a list of questions for the game.</returns>
        public static List<Question> GenerateQuestionsForGame()
        {
            List<Question> questions = new List<Question>();
            string continueAdding;

            do
            {
                // Take a question from the user
                Question question = new Question(GUI.TakeUserQuestion(), GUI.TakeUserAnswers());

                // Add the question to the list
                questions.Add(question);

                while (true)
                {
                    Console.WriteLine("Do you want to add more questions? (Y/N)");
                    continueAdding = Console.ReadLine().ToUpper();

                    if (continueAdding.Equals("Y") || continueAdding.Equals("N"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Only Y/N are accepted. Please enter a valid input:");
                    }
                }

                // Continue adding questions as long as the user enters "Y"
            } while (continueAdding.Equals("Y"));

            return questions;
        }

        /// <summary>
        /// Shuffles the order of the questions in the given list using the Fisher-Yates algorithm.
        /// </summary>
        /// <param name="questions">The list of questions to shuffle.</param>
        /// <returns>A shuffled list of questions.</returns>
        public static List<Question> ShuffleQuestions(List<Question> questions)
        {
            Random rnd = new Random();

            // Shuffle the indices using the Fisher-Yates shuffle algorithm
            for (int i = questions.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Question temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }

            return questions;
        }
    }
}
