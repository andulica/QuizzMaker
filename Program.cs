using QuizMakerProgram;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //while(true)
            //{

            //GUI.TakeUserQuestion();
            //    List<string> answers = GUI.TakeUserAnswers();
            //    GUI.DisplayAnswers(answers);


            //}
            GUI.DisplayMenu();
            GUI.WelcomeMessage();
            GUI.Divider();

            List <Question> questions =   QuizLogic.GenerateQuestionsForGame();
           
            
            QuizLogic.Serialization(GUI.GetNameForFile(), questions);
            questions = QuizLogic.Deserialize(GUI.GetNameForFile());

            QuizLogic.DisplayQuestionsAndAnswers(questions);
            
           
        }

       
    }
}