using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangaTranslator
{
    public class LanguageCore
    {
        public static LanguageModel GetLanguageToGetTokenDeepL()
        {
            var model = new LanguageModel();
            model.Russia = new string[] { "Введите API ключ DeepL", "Подтвердить"};
            model.English = new string[] { "Enter the DeepL API key", "Confirm"};
            return model;
        }
    }
}
