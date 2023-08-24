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
                userChosenOption = (GameModes)GUI.TakeUserInput((int)GameModes.Play, (int)GameModes.Exit);
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

        internal static void PlayQuestionsFromFile(List<Question> questionsToPlay)
        {
            int individualQuestionScore = 0;
            int generalGameScore = 0; // Initialize the user's score
            bool repeat = true; // Variable to control whether the quiz will repeat

            // Continue playing as long as the user wants to repeat
            while (repeat)
            {
                List<Question> shuffledListOfQuestions = QuizLogic.ShuffleQuestions(questionsToPlay); // Shuffle the list of questions

                // Loop through all the questions
                for (int i = 0; i < questionsToPlay.Count; i++)
                {
                    GUI.DisplayQuestionItsAnswers(shuffledListOfQuestions[i]); // Display the current question and its answers
                    int correctAnswers = shuffledListOfQuestions[i].Answers.Count(answer => answer.Contains('*')); // Count the correct answers for the current question
                    bool firstCheckedCorrectAnswer = false; // Track whether the first correct answer has been checked

                    // Loop through the correct answers
                    for (int j = 0; j < correctAnswers; j++)
                    {
                        // Take the player's selected answer (1-based index)
                        int answer = GUI.TakeUserInput(Constants.MAX_ANSWERS_PER_QUESTION);

                        // Evaluate the player's answer, and decrement the score if incorrect
                        if (!QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            Console.WriteLine("Incorrect ... Better luck next time.");
                            individualQuestionScore = 0;
                            break; // Exit the loop if the answer is incorrect
                        }

                        // Evaluate the player's answer and increment the score if correct
                        if (QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            firstCheckedCorrectAnswer = true;
                            individualQuestionScore++;
                        }

                        // Check if the correct answers equal the score, and handle special case where score is greater than 1
                        if (correctAnswers == individualQuestionScore)
                        {

                            generalGameScore += individualQuestionScore - j;

                            Console.WriteLine("You got the correct answer(s)!");
                            individualQuestionScore = 0;
                            break;
                        }

                        // Prompt the user if there are more than one correct answer
                        if (firstCheckedCorrectAnswer && QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                        {
                            Console.WriteLine($"There are more than {j + 1} correct answer(s). Please enter the next answer: ");
                        }
                    }
                }
                GUI.DisplayScore(generalGameScore, questionsToPlay); // Display the final score
                generalGameScore = 0; // Reset the score for the next quiz iteration (if repeated)
                repeat = GUI.RepeatQuestions(); // Ask the user if they want to repeat the quiz
            }

            GUI.DisplayReturnToMainMenu(null); // Display return to main menu option
        }
    }
}