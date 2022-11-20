using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using YandexBookTranslator.Infrastructure.Commands;
using YandexBookTranslator.Models;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class TranslationControlViewModel : ViewModel
    {
        #region Свойства ViewModel
        #region Список файлов - FilesList
        private List<TranslationFilesInfo> _TranslationFilesInfoList;
        public List<TranslationFilesInfo> TranslationFilesInfoList
        {
            get => _TranslationFilesInfoList;
            set
            {
                Set(ref _TranslationFilesInfoList, value);
                OnPropertyChanged("TranslationFileNameList");
            }
        }
        public string TranslationFileNameList
        {
            get
            {
                string fileNames;
                if (_TranslationFilesInfoList.Count != 0)
                {
                    fileNames = _TranslationFilesInfoList.First().FileName;
                    foreach (var file in _TranslationFilesInfoList.Skip(1))
                    {
                        fileNames += "\r\n" + file.FileName;
                    }
                }
                else
                {
                    fileNames = "Файлы";
                }
                return fileNames;
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

        #region Команды ViewModel
        #region Команда добавления файлов для перевода - ChooseTranslationFilesCommand

        public ICommand ChooseTranslationFilesCommand { get; }
        public bool CanChooseTranslationFilesCommandExecute(object p) => true;
        public void OnChooseTranslationFilesCommandExecuted(object p)
        {
            var numTemplate = int.Parse(p.ToString());
            switch(numTemplate)
            {
                case 1:
                    TranslationFilesInfoList = new List<TranslationFilesInfo>()
                    {
                        new TranslationFilesInfo("C:\\1.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\2.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\3.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\4.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                    };
                    break;
                case 2:
                    TranslationFilesInfoList = new List<TranslationFilesInfo>()
                    {
                        new TranslationFilesInfo("C:\\one.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\two.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\three.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\four.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                    };
                    break;
                default:
                    TranslationFilesInfoList = new List<TranslationFilesInfo>()
                    {
                        new TranslationFilesInfo("C:\\apple.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\orange.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\peage.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                        new TranslationFilesInfo("C:\\plum.docx", Langs.First().Key, Langs.Skip(1).First().Key),
                    };
                    break;
            }
        }

        public ICommand TestCommand { get; }
        public bool CanTestCommandExecute(object p) => true;
        public void OnTestCommandExecuted(object p)
        {
            Console.WriteLine(String.Join("\n", TranslationFilesInfoList.AsEnumerable()));
        }


        #endregion
        #endregion

        public TranslationControlViewModel()
        {
            ChooseTranslationFilesCommand = new LambdaCommand(OnChooseTranslationFilesCommandExecuted, CanChooseTranslationFilesCommandExecute);
            TestCommand = new LambdaCommand(OnTestCommandExecuted, CanTestCommandExecute);

            TranslationFilesInfoList = new List<TranslationFilesInfo>();
            //_TranslationFilesInfoList.Add(new TranslationFilesInfo("C:\\1.docx"));
            SaveDir= "Директория";

            Langs= new Dictionary<string, string>()
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
