using System.Xml.Serialization;

namespace QuizMakerProgram
{
    public class QuizLogic
    {
        public XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
        public static int EvaluatePlayerAnswer(List<String> answersList, String answer)
        {
            int winnings = 0;
            for (int i = 1; i <= answersList.Count; i++)
            {
                if (answersList[i].Equals(answer))
                {
                    winnings += 1;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Better luck next time");
                }
            }
            return winnings;
        }

        public static string[] RemoveAsterisksFromAnswers(string[] answersWithStar)
        {
            char star = '*';
            string[] answersWithoutStar = new string[5];
            for (int i = 0; i < answersWithStar.Length; i++)
            {
                if (answersWithStar[i].Contains('*'))
                {
                    string answerWithoutStar = answersWithStar[i].Replace(star.ToString(), "");
                    answersWithoutStar[i] = answerWithoutStar;

                }
                else
                {
                    answersWithoutStar[i] = answersWithStar[i];
                }
            }
            return answersWithoutStar;
        }

        public static void DisplayQuestionsAndAnswers(List<Question> questions)
        {
            string[] answersWithoutStar = new string[5];

            for (int i = 0; i < questions.Count; i++)
            {
                answersWithoutStar = RemoveAsterisksFromAnswers(questions[i].Answers);
                Console.WriteLine($"Question {i + 1} is {questions[i].QuestionString} and the answers are: ");

                for (int j = 0; j < questions[i].Answers.Length; j++)
                {
                    Console.WriteLine($" {j + 1}: {answersWithoutStar[j]} ");
                }
            }
        }


        public static List<Question> GenerateQuestionsForGame()
        {
            List<Question> questions = new List<Question>();
            char exit = 'Y';

            while (exit.Equals('Y'))
            {
                Question question = new Question();
                string[] answers = new string[5];

                Console.WriteLine("Enter the question");
                question.QuestionString = Console.ReadLine();

                Console.WriteLine("Enter the answers for this question");
                for (int i = 0; i < answers.Length; i++)
                {
                    answers[i] = Console.ReadLine();
                }
                question.Answers = answers;

                questions.Add(question);
                Console.WriteLine("Do you want to add more questions? (Y/N)");
                exit = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
            }
            return questions;
        }


        public static void Serialization(string fileName, List<Question> questionList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

            var path = $@"C:\temp\{fileName}.xml";

            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, questionList);
            }
        }


        // 3. Randomly choose a question object from the list


        public static List<Question> Deserialize(string fileName)
        {
            List<Question> questions;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));


            var path = $@"C:\temp\{fileName}.xml";

            using (FileStream file = File.OpenRead(path))
            {
                Console.WriteLine("Deserialize succesful");
                return questions = serializer.Deserialize(file) as List<Question>;
            }
        }
    }
}
