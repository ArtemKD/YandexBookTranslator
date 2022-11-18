using System;
using System.Collections.Generic;
using System.Linq;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class TranslationControlViewModel : ViewModel
    {
        #region Свойства ViewModel
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
                return _Langs.Keys.ToList();
            }
        }
        #endregion

        #region Выбранный исходный язык перевода - SelectedSourceLang
        private string _SelectedSourceLang;
        public string SelectedSourceLang
        {
            get => _SelectedSourceLang;
            set => Set(ref _SelectedSourceLang, value);
        }
        #endregion

        #region Выбранный конечный язык перевода - SelectedTargetLang
        private string _SelectedTargetLang;
        public string SelectedTargetLang
        {
            get => _SelectedTargetLang;
            set => Set(ref _SelectedTargetLang, value);
        }
        #endregion

        #endregion

        public TranslationControlViewModel()
        {
            _FilesList = new List<string>();
            _FilesList.Add("Файлы");
            _SaveDir= "Директория";

            _Langs= new Dictionary<string, string>()
            {
                {"Русский", "ru" },
                {"Английский", "en" },
                {"Китайский", "zh" },
                {"Французский", "fr" }
            };

            SelectedSourceLang = Langs.First().Key;
            SelectedTargetLang = Langs.Skip(1).First().Key;
        }
    }
}
