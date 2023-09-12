using OpenAI_API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mangaTranslator
{
    class OpenAITranslater
    {
        string Model = "gpt-3.5-turbo";
        string Token;
        public OpenAITranslater(string token)
        {
            Token = token;
        }
        public OpenAITranslater(string token, string model)
        {
            Token = token;
            Model = model;
        }
        public static string GetDefaultModel()
        {
            return "gpt-3.5-turbo";
        }
        public async Task<string> TranslateText(string language, string text)
        {

            var apiKey = Token;
            var apiModel = Model;

            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = $"Translate this into {language}\r\n{text}",
                Model = apiModel,
                Temperature = 0.3,
                MaxTokens = 100,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,
            };

            var result = await api.Completions.CreateCompletionsAsync(completionRequest);
            return result.Completions[0].Text;
        }

    }
}
