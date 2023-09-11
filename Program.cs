using QuizMakerProgram;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            GUI.DisplayWelcomeMessage();
            GameModes userChosenOption;
            do
            {
                GUI.DisplayMenu();
                userChosenOption = (GameModes)GUI.GetUserChoiceIndex((int)GameModes.Exit);
                switch (userChosenOption)
                {
                    case GameModes.Play:
                        QuizEditor.SelectQuizToPlay();
                        break;
                    case GameModes.Create:
                        QuizEditor.CreateQuiz();
                        break;
                    case GameModes.Delete:
                        QuizEditor.DeleteQuiz();
                        break;
                    case GameModes.Edit:
                        QuizEditor.EditQuiz();
                        break;
                    case GameModes.Rules:
                        GUI.DisplayGameRules();
                        break;
                    case GameModes.Exit:
                        GUI.DisplayExitMessage();
                        break;
                    default:
                        break;
                }
            }
            while (userChosenOption != GameModes.Exit);
        }

        /// <summary>
        /// Executes the quiz game using a list of questions. Each question is presented to the user one at a time,
        /// the user's answers are collected and evaluated, and the user's score is updated accordingly.
        /// The quiz will repeat if the user decides to play again.
        /// </summary>
        /// <param name="questionsToPlay">A list of questions that will be used in the quiz.</param>
        internal static void PlayQuestionsFromFile(List<Question> questionsToPlay)
        {
            // Flag to determine if the user wants to repeat the quiz
            bool repeat = true;

            // Main loop to handle replaying the quiz
            while (repeat)
            {
                // Initialize the total score for the current game session
                int generalGameScore = 0;

                // Shuffle the list of questions for randomness
                List<Question> shuffledListOfQuestions = QuizLogic.ShuffleQuestions(questionsToPlay);

                // Loop through each question in the shuffled list
                for (int i = 0; i < questionsToPlay.Count; i++)
                {
                    // Initialize the score for the current individual question
                    int individualQuestionScore = 0;

                    // Display the current question and its answer options
                    GUI.DisplayQuestionItsAnswers(shuffledListOfQuestions[i]);

                    // Count the number of correct answers for the current question
                    int correctAnswers = shuffledListOfQuestions[i].Answers.Count(answer => answer.Contains(Constants.CORRECT_ANSWER_MARKER));

                    // HashSet to keep track of answers that have already been selected by the user
                    HashSet<int> selectedAnswers = new HashSet<int>();

                    // Loop to collect and evaluate user's answers for questions with multiple correct answers
                    for (int j = 0; j < correctAnswers; j++)
                    {
                        int option;
                        // Make sure the user doesn't select an answer they've already chosen
                        do
                        {
                            option = GUI.GetUserChoiceIndex(Constants.MAX_ANSWERS_PER_QUESTION);
                        } while (selectedAnswers.Contains(option));

                        // Add the selected answer to the HashSet
                        selectedAnswers.Add(option);

                        // Evaluate if the selected answer is correct
                        bool isCorrect = QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, option);

                        // If the answer is incorrect, notify the user and break the loop
                        if (!isCorrect)
                        {
                            Console.WriteLine("Incorrect ... Better luck next time.");
                            break;
                        }

                        // Increment the score for the individual question
                        individualQuestionScore++;

                        // If all correct answers have been identified, update the total score
                        if (correctAnswers == individualQuestionScore)
                        {
                            generalGameScore += individualQuestionScore - j;
                            Console.WriteLine("You got the correct answer(s)!");
                            break;
                        }

                        // Notify the user if there are more correct answers to identify
                        Console.WriteLine($"There are more than {j + 1} correct answer(s). Please enter the next answer: ");
                    }
                }

                // Display the total score for the current game session
                GUI.DisplayScore(generalGameScore, questionsToPlay);

                // Ask the user if they wish to play again
                repeat = GUI.RepeatQuestions();
            }

            // Display the option to return to the main menu
            GUI.DisplayReturnToMainMenu(string.Empty);
        }
    }
}