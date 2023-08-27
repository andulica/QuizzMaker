namespace QuizMakerProgram
{
    public class Question
    {
        public string QuestionString { get; set; }
        public string[] Answers { get; set; }

        public Question ()
        {

        }

        public Question(string question, string[] answers)
        {
            QuestionString = question;
            Answers = answers;
        }
    }
}
