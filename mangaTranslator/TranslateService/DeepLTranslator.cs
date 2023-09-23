using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaTranslator.TranslateService
{
    public class DeepLTranslator : TranslateTool
    {
        string Token;
        public DeepLTranslator(string token)
        {
            Token = token;
        }
        public override async Task<string> Translate(string text, string from, string to)
        {
            DeepL.Translator translator = new DeepL.Translator(Token);
            var res = await translator.TranslateTextAsync(text, from, to);
            return res.ToString();
        }
    }
}
