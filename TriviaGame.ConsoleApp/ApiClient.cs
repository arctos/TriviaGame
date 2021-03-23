using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TriviaGame.ConsoleApp
{
    public static class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string Endpoint = "https://opentdb.com/api.php?amount=1";

        public static async Task<Question> GetQuestionAsync()
        {
            Client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = Client.GetStreamAsync(Endpoint);
            var apiResponse = await JsonSerializer.DeserializeAsync<ApiResponse>(await streamTask);

            return apiResponse.Results[0];
        }
    }
}