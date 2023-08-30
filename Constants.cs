namespace QuizMakerProgram
{
    public static class Constants
    {
        public const int MAX_ANSWERS_PER_QUESTION = 5;
        public const int MIN_ANSWERS_PER_QUESTION = 3;
        public static readonly string BASE_PATH = AppDomain.CurrentDomain.BaseDirectory;
        public const string DELETE_MESSAGE = "Press Y for 'Yes' and N for 'No':";
        public const string EXIT_MESSAGE = "Do you want to exit?";
        public const string NO_MORE_QUESTIONS_MESSAGE = "No more questions.";
        public const string FILES_DELETED_MESSAGE = "File deleted successfully.";
        public const string DELETION_CANCELED_MESSAGE = "Deletion canceled.";
        public const char CHOICE_YES = 'Y';
        public const char CHOICE_NO = 'N';
        public const string CORRECT_ANSWER_MARKER = "*";
    }
}
