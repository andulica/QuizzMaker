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

        /// <summary>
        /// Plays the quiz game using a list of questions.
        /// This method continuously selects random questions from the list and presents them to the user for answering.
        /// A correct answer increments the user's score.
        /// After all questions are answered, the user has the option to repeat the quiz or exit back to the main menu.
        /// </summary>
        /// <param name="questionsToPlay">The list of questions to be played in the quiz game.</param>
        /// <returns>Returns the total score achieved by the user.</returns>
        internal static void PlayQuestionsFromFile(List<Question> questionsToPlay)
        {
            int score = 0;
            bool repeat = true;

            // Continue playing as long as the user wants to repeat
            while (repeat)
            {
                List<Question> shuffledListOfQuestions = QuizLogic.ShuffleQuestions(questionsToPlay);
                for (int i = 0; i < questionsToPlay.Count; i++)
                {

                    GUI.DisplayQuestionItsAnswers(shuffledListOfQuestions[i]);

                    // Take the player's selected answer (1-based index)
                    int answer = GUI.TakeUserInput(Constants.MAX_ANSWERS_PER_QUESTION);

                    // Evaluate the player's answer and increment the score if correct
                    if (QuizLogic.EvaluatePlayerAnswer(shuffledListOfQuestions[i].Answers, answer))
                    {
                        score++;
                    }
                }
                GUI.DisplayScore(score, questionsToPlay);
                // Ask the user if they want to repeat the quiz
                repeat = GUI.RepeatQuestions();
            }

            GUI.DisplayReturnToMainMenu(null);
        }
    }
}