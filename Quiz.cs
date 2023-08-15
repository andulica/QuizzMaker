using System.Xml.Serialization;

namespace QuizMakerProgram
{
    internal class Quiz
    {
        /// <summary>
        /// Serializes a list of questions into an XML file with the specified file name.
        /// This method is used to save the questions to a file so that they can be retrieved and used later.
        /// </summary>
        /// <param name="fileName">The name of the file where the questions will be saved, without the extension.</param>
        /// <param name="questionList">The list of questions to be serialized into the file.</param>
        public static void Serialize(List<Question> questionList)
        {
            // Take name for file from the user
            string fileName = GUI.TakeNameForFileFromUser();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

            // Concatenate the base path with the file name and the extension to form the full path
            var path = $"{Constants.BASE_PATH}{fileName}.xml";

            // Create and open a file stream for the specified path
            using (FileStream file = File.Create(path))
            {
                // Serialize the list of questions into the XML file
                serializer.Serialize(file, questionList);
            }
        }

        /// <summary>
        /// Deserializes a list of questions from an XML file at the specified path.
        /// This method is used to load previously saved questions from a file into memory for further use.
        /// </summary>
        /// <param name="filePath">The full path to the XML file containing the serialized list of questions.</param>
        /// <returns>A list of questions deserialized from the file.</returns>
        public static List<Question> Deserialize(string filePath)
        {
            // Create an XmlSerializer for the List<Question> type
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

            // Open a file stream for reading the specified XML file
            using (FileStream file = File.OpenRead(filePath))
            {
                // Deserialize the XML content of the file into a List<Question> and return it
                return serializer.Deserialize(file) as List<Question>;
            }
        }

        /// <summary>
        /// Replaces the list of questions in the specified XML file with the given list of questions.
        /// </summary>
        /// <param name="filePath">The path to the XML file where the questions will be saved.</param>
        /// <param name="questions">The list of Question objects to be serialized into the XML file.</param>
        public static void ReplaceListOfQuestions(string filePath, List<Question> questions)
        {
            // Create an XmlSerializer for the List<Question> type
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

            // Create or overwrite the specified file using a StreamWriter
            using (StreamWriter file = File.CreateText(filePath))
            {
                // Serialize the list of questions into the XML file
                serializer.Serialize(file, questions);
            }
        }
    }
}
