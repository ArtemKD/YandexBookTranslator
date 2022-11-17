using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class InformationViewModel : ViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public InformationViewModel()
        {
            Title = "Информация";
            Description = "Какое=то описание";
        }
    }
}
