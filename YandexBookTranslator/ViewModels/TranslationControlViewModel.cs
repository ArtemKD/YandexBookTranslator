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
        #region Список файлов - FilesList
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
                string files = _FilesList.First();
                foreach(var file in _FilesList.Skip(1))
                {
                    files += "\r\n" + file;
                }
                return files;
            }
            set
            {

            }
        }
        #endregion

        #region Директория перевода - SaveDir
        private string _SaveDir;
        public string SaveDir
        {
            get => _SaveDir;
            set => Set(ref _SaveDir, value);
        }
        #endregion
        #region Список поддерживаемых языков - Langs
        private Dictionary<string, string> _Langs;
        public Dictionary<string, string> Langs
        {
            get => _Langs;
            set => Set(ref _Langs, value);
        }

        public List<string> NameOfLangs
        {
            get
            {
                return _Langs.Values.ToList();
            }
        }
        #endregion

        public TranslationControlViewModel()
        {
            _FilesList = new List<string>();
            _FilesList.Add("Файлы");
            _SaveDir= "Директория";

            _Langs= new Dictionary<string, string>()
            {
                {"ru", "Русский" },
                {"en", "Английский" },
                {"zh", "Китайский" },
                {"fr", "Французский" }
            };
        }
    }
}
