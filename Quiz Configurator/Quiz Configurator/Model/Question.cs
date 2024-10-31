using System.Text.Json.Serialization;

namespace Quiz_Configurator.Model
{
    class Question
    {
        [JsonPropertyName("question")]
        public string Query { get; set; }
        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }
        [JsonPropertyName("incorrect_answers")]
        public string[] IncorrectAnswers { get; set; }

        public Question()
        {
            IncorrectAnswers = new string[3];
        }

        public Question(string query, string correctAnswer, string incorrectAnswer1, string incorrectAnswer2, string incorrectAnswer3)
        {
            Query = query;
            CorrectAnswer = correctAnswer;
            IncorrectAnswers = new string[3] { incorrectAnswer1, incorrectAnswer2, incorrectAnswer3 };
        }
    }
}
