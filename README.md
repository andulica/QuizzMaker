Basic console app that allows users to create their own quizzes and then take the tests. The questions order is randomised and they get written in a XML file on your computer. Just change the file path or leave it as it is for where you want to read and write the questions in here:

[﻿namespace QuizMakerProgram
{
    public static class Constants
    {
        public const int MAX_ANSWERS_PER_QUESTION = 5;
        public const int MIN_ANSWERS_PER_QUESTION = 3;
        public static readonly string BASE_PATH = AppDomain.CurrentDomain.BaseDirectory;
        public const string DELETE_MESSAGE = "Press Y for 'Yes' and N for 'No':";
        public const string NO_MORE_QUESTIONS_MESSAGE = "No more questions.";
        public const string FILES_DELETED_MESSAGE = "File deleted successfully.";
        public const string DELETION_CANCELED_MESSAGE = "Deletion canceled.";
        public const char CHOICE_YES = 'Y';
        public const char CHOICE_NO = 'N';
        public const string CORRECT_ANSWER_MARKER = "*";
    }
}](https://github.com/andulica/QuizzMaker/blob/c654a4141d1a1db90005f613fcc37a4b6dd5b0e6/Constants.cs#L1-L16)
