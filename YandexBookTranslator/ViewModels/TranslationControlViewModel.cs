using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class TranslationControlViewModel : ViewModel
    {
        #region Список файлов
        private List<string> _FilesList;
        public List<string> FilesList
        {
            get => _FilesList;
            set => Set(ref _FilesList, value);
        }
        public String FilesListString
        {
            get
            {
                string files = string.Empty;
                foreach(var file in _FilesList)
                {
                    files += file + "\r\n";
                }
                return files;
            }
            set
            {

            }
        }
        #endregion

        public TranslationControlViewModel()
        {
            _FilesList = new List<string>();
        }
    }
}
