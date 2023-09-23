using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaTranslator.TranslateService
{
    public abstract class TranslateTool
    {
        public abstract Task<string> Translate(string text, string from, string to);

        public static TranslateTool CreateService(string service)
        {
            if (service == "google")
            {
                return new GoogleTranslator();
            }
            else if(service == "openai")
            {
                return OpenAITranslater.Create();
            }
            else
            {
                return new DeepLTranslator(Properties.Settings.Default.DeppLToken);
            }
        }
    }
}
