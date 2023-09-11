using ConsoleApp1;

namespace QuizMakerProgram
{
    public class QuizEditor
    {

        /// <summary>
        /// Selects a quiz from available XML files and starts the game.
        /// </summary>
        public static List<Question> SelectQuizToPlay()
        {
            // Display available XML files (quizzes) to the user
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            // Deserialize selected XML file into a list of questions
             List<Question> questionsToPlay = GUI.SelectXmlFile(Constants.BASE_PATH);

            return questionsToPlay;
            
        }

        /// <summary>
        /// Generates a new quiz by creating a set of questions and serializing them to an XML file.
        /// </summary>
        public static void CreateQuiz()
        {
            // Generate questions for the game using QuizLogic and serialize them to an XML file using Quiz.Serialization
            XMLFileOperations.Serialize(GUI.TakeQuestionsForQuiz());
            GUI.DisplayReturnToMainMenu(string.Empty);
        }

        /// <summary>
        /// Allows the user to select a quiz from available XML files, edit the questions, and save the changes back to the file.
        /// </summary>
        public static void EditQuiz()
        {
            // Display available XML files (quizzes) to the user
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            // Allow the user to select an XML file and deserialize it into a list of questions, also retrieving the file path
            string filePath = GUI.SelectXmlFileAndFilePath(Constants.BASE_PATH);
            var result = XMLFileOperations.Deserialize(filePath);

            // Display the existing questions to the user
            GUI.DisplayQuestions(result);

            // Allow the user to edit the questions
            List<Question> questionsEdited = GUI.EditQuestionsList(result);

            // Save the edited questions back to the original XML file
            XMLFileOperations.ReplaceListOfQuestions(filePath, questionsEdited);

            GUI.DisplayReturnToMainMenu(string.Empty);
        }

        /// <summary>
        /// Facilitates the deletion of a quiz. It displays the list of available XML quiz files,
        /// prompts the user to select one, and then deletes the selected file.
        /// </summary>
        public static void DeleteQuiz()
        {
            // Display the list of available XML quiz files for the user
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);

            // Prompt the user to select an XML file and retrieve its full path
            string filePath = GUI.SelectXmlFileAndFilePath(Constants.BASE_PATH);

            // Deserialize the selected XML file (if further operations or checks are needed on the deserialized data in future implementations)
            var result = XMLFileOperations.Deserialize(filePath);

            // Delete the selected XML file
            GUI.DeleteQuiz(filePath);
        }
    }
}
