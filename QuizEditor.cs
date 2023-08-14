using ConsoleApp1;

namespace QuizMakerProgram
{
    public class QuizEditor
	{

        public static void SelectQuizToPlay()
        {
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);
            List<Question> questionsToPlay = GUI.SelectXmlFile(Constants.BASE_PATH);

            GUI.DisplayCredits(Program.PlayQuestionsFromFile(questionsToPlay));
        }

        public static void CreateQuiz()
        {
            Quiz.Serialization(QuizLogic.GenerateQuestionsForGame());
        }

        public static void EditQuiz()
        {
            GUI.DisplayAllXmlFiles(Constants.BASE_PATH);
            var result = GUI.SelectXmlFileAndFilePath(Constants.BASE_PATH);
            GUI.DisplayQuestions(result.Questions);
            List <Question> questionsEdited = GUI.EditQuestionsList(result.Questions);
            Quiz.ReplaceListOfQuestions(result.FilePath, questionsEdited);
        }

        public static void DeleteQuiz()
        {
            throw new NotImplementedException();
        }
    }
}
