using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexBookTranslator.Models
{
    internal class TranslationFilesInfo
    {
        public string PathFile { get; set; }
        public string FileName { get; set; }
        public string SelectedSourceLang { get; set; }
        public string SelectedTargetLang { get; set; }

        public TranslationFilesInfo(string pathFile, string selectedSourceLang, string selectedTargetLang)
        {
            PathFile = pathFile;
            FileName = pathFile.Split('\\').Last();

            SelectedSourceLang = selectedSourceLang;
            SelectedTargetLang = selectedTargetLang;
        }

        public override string ToString()
        {
            return PathFile + " | " + FileName + " | " + SelectedSourceLang + " | " + SelectedTargetLang;
        }
    }
}
