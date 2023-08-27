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
                userChosenOption = (GameModes)GUI.TakeUserInput((int)GameModes.Exit);
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
        /// Runs the game by playing questions from a given list of questions. Questions are displayed to the user, 
        /// answers are collected and evaluated, and scores are updated and displayed.
        /// </summary>
        /// <param name="questionsToPlay">A list of questions that the user will attempt.</param>
        internal static void PlayQuestionsFromFile(List<Question> questionsToPlay)
        {
            // The score for an individual question
            int individualQuestionScore = 0;

            // Total score for all questions in the game session
            int generalGameScore = 0;

            // Flag to determine if the user wants to repeat the quiz
            bool repeat = true;

            // The quiz will continue as long as the user wishes to repeat
            while (repeat)
            {
                // Shuffle the list of questions to provide randomness
                List<Question> shuffledListOfQuestions = QuizLogic.ShuffleQuestions(questionsToPlay);

                // Iterate over all questions and present them to the user
                for (int i = 0; i < questionsToPlay.Count; i++)
                {
                    // Show the current question and its answer options
                    GUI.DisplayQuestionItsAnswers(shuffledListOfQuestions[i]);

                    // Determine the number of correct answers for the current question
                    int correctAnswers = shuffledListOfQuestions[i].Answers.Count(answer => answer.Contains(Constants.CORRECT_ANSWER_MARKER));

                    // Flag to check if the first correct answer has been verified
                    bool firstCheckedCorrectAnswer = false;

                    // Iterate through all correct answers and verify the user's inputs
                    for (int j = 0; j < correctAnswers; j++)
                    {
                        // Get the user's answer (assuming a 1-based index)
                        int answer = GUI.TakeUserInput(Constants.MAX_ANSWERS_PER_QUESTION);

                        // Check if the given answer is incorrect
                        if (!QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            Console.WriteLine("Incorrect ... Better luck next time.");
                            individualQuestionScore = 0;
                            break; // Exit the loop if the user's answer is incorrect
                        }

                        // Check if the given answer is correct
                        if (QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            firstCheckedCorrectAnswer = true;
                            individualQuestionScore++;
                        }

                        // Update the total score if all correct answers have been identified
                        if (correctAnswers == individualQuestionScore)
                        {
                            generalGameScore += individualQuestionScore - j;

                            Console.WriteLine("You got the correct answer(s)!");
                            individualQuestionScore = 0;
                            break;
                        }

                        // Notify the user if there are multiple correct answers
                        if (firstCheckedCorrectAnswer && QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            Console.WriteLine($"There are more than {j + 1} correct answer(s). Please enter the next answer: ");
                        }
                    }
                }

                // Display the total score for the current game session
                GUI.DisplayScore(generalGameScore, questionsToPlay);

                // Reset the game's score for a potential next session
                generalGameScore = 0;

                // Ask the user if they wish to play again
                repeat = GUI.RepeatQuestions();
            }

            // Once done, offer an option to return to the main menu
            GUI.DisplayReturnToMainMenu(null);
        }
    }
}