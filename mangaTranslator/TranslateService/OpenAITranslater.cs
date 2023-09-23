using DeepL.Model;
using mangaTranslator.TranslateService;
using OpenAI_API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mangaTranslator
{
    class OpenAITranslater : TranslateTool
    {
        public static OpenAITranslater Create()
        {
            if (Properties.Settings.Default.OpenAIApiKey != "none")
            {
                string model = OpenAITranslater.GetDefaultModel();
                if (Properties.Settings.Default.OpenAIModel != "none")
                {
                    model = Properties.Settings.Default.OpenAIModel;
                }
                var t = new OpenAITranslater(Properties.Settings.Default.OpenAIApiKey, model);
                return t;
            }
            return null;
        }
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

        public override async Task<string> Translate(string text, string from, string to)
        {
            var apiKey = Token;
            var apiModel = Model;

            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = $"Translate this into {to}\r\n{text}",
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
