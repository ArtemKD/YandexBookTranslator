using System.Collections.Generic;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class TranslationHistoryViewModel : ViewModel
    {
        public List<string> Translations { get; set; }

        public TranslationHistoryViewModel()
        {
            Translations = new List<string>();
            Translations.Add("one");
            Translations.Add("two");
            Translations.Add("three");
            Translations.Add("four");
        }
    }
}
