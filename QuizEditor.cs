using ConsoleApp1;

namespace QuizMakerProgram
{
    public class QuizEditor
	{

        /// <summary>
        /// Selects a quiz from available XML files and starts the game.
        /// </summary>
        public static void SelectQuizToPlay()
        {
            // Display available XML files (quizzes) to the user
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            // Deserialize selected XML file into a list of questions
            List<Question> questionsToPlay = GUI.SelectXmlFile(Constants.BASE_PATH);

            // Play the selected quiz and display the result (e.g., user's score)
            Program.PlayQuestionsFromFile(questionsToPlay);
        }

        /// <summary>
        /// Generates a new quiz by creating a set of questions and serializing them to an XML file.
        /// </summary>
        public static void CreateQuiz()
        {
            // Generate questions for the game using QuizLogic and serialize them to an XML file using Quiz.Serialization
            Quiz.Serialization(QuizLogic.GenerateQuestionsForGame());
        }

        /// <summary>
        /// Allows the user to select a quiz from available XML files, edit the questions, and save the changes back to the file.
        /// </summary>
        public static void EditQuiz()
        {
            // Display available XML files (quizzes) to the user
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            // Allow the user to select an XML file and deserialize it into a list of questions, also retrieving the file path
            var result = GUI.SelectXmlFileAndFilePath(Constants.BASE_PATH);

            // Display the existing questions to the user
            GUI.DisplayQuestions(result.Questions);

            // Allow the user to edit the questions
            List<Question> questionsEdited = GUI.EditQuestionsList(result.Questions);

            // Save the edited questions back to the original XML file
            Quiz.ReplaceListOfQuestions(result.FilePath, questionsEdited);
        }

        public static void DeleteQuiz()
        {
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            var result = GUI.SelectXmlFileAndFilePath(Constants.BASE_PATH);

            GUI.DeleteQuiz(result);
        }
    }
}
