using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class TranslateViewModel : ViewModel
    {
        public string Title { get; set; }
        public string SavePath { get; set; }
        public string FileList { get; set; }

        public TranslateViewModel()
        {
            Title = "Переводчик";
            SavePath = "C:\\ProgramFiles";
            FileList = "1.docx 2.docx";
        }
    }
}
