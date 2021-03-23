using System.Text.Json.Serialization;

namespace TriviaGame.ConsoleApp
{
    public class Question
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("question")]
        public string Text { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrect_answers")]
        public string[] IncorrectAnswer { get; set; }
    }
}