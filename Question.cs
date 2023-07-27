using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMakerProgram
{
    internal class Question
    {
        private String questionString;
        private int[] answers;


        public Question(String question, int[] answers)
        {
            this.questionString = question;
            this.answers = answers;
        }


        public String GetQuestionString()
        {
            return this.questionString;
        }

        public int[] GetAnswers()
        {
            return this.answers;
        }


        public void SetQuestion(String question)
        {
            this.questionString = question;

        }

        public void SetAnswers(int[] answers)
        {
            this.answers = answers;
        }
    }
}
