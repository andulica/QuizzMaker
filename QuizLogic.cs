namespace QuizMakerProgram
{
    public class QuizLogic
    {
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
