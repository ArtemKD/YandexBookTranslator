using System;
using System.IO;
using System.Windows.Input;
using YandexBookTranslator.Infrastructure.Commands;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private TranslationHistoryViewModel _HistoryVM;
        public TranslationHistoryViewModel HistoryVM
        {
            get => _HistoryVM;
            set => Set(ref _HistoryVM, value);
        }

        private TranslationControlViewModel _TranslateVM;
        public TranslationControlViewModel TranslateVM
        {
            get => _TranslateVM;
            set => Set(ref _TranslateVM, value);
        }

        #region SelectViewModel
        private object _SelectedViewModel;
        public object SelectedViewModel
        {
            get => _SelectedViewModel;
            set => Set(ref _SelectedViewModel, value);
        }
        #endregion

        #region Комманды
        #region Команда выбора вкладки истории перевода - OpenHistoryCommand
        public ICommand OpenHistoryCommand { get; }
        private bool CanOpenHistoryCommandExecute(object p)
        {
            return !SelectedViewModel.Equals(HistoryVM);
        }
        private void OnOpenHistoryCommandExecuted(object p)
        {
            SelectedViewModel = HistoryVM;
        }
        #endregion

        #region Команда открытия вкладки перевода - OpenTransalteCommand
        public ICommand OpenTransalteCommand { get; }
        private bool CanOpenTransalteCommandExecute(object p) => !SelectedViewModel.Equals(TranslateVM);
        private void OnOpenTransalteCommandExecuted(object p)
        {
            SelectedViewModel = TranslateVM;
        }
        #endregion

        #region Команда начала перевода - StartTranslationCommand
        public ICommand StartTranslationCommand { get; }
        private bool CanStartTranslationCommandExecute(object p)
        {
            if (TranslateVM.SaveDir != "Директория" && TranslateVM.TranslationFilesInfoList.Count > 0) return true;
            return false;
        }
        private void OnStartTranslationCommandExecuted(object p)
        {
            StreamWriter streamWriter = new StreamWriter($"{DateTime.Now:dd-MM-yyyy_HH-mm-ss}");
            foreach (var item in TranslateVM.TranslationFilesInfoList)
            {
                streamWriter.WriteLine(item);
            }
            streamWriter.Close();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {

            OpenHistoryCommand = new LambdaCommand(OnOpenHistoryCommandExecuted, CanOpenHistoryCommandExecute);
            OpenTransalteCommand = new LambdaCommand(OnOpenTransalteCommandExecuted, CanOpenTransalteCommandExecute);
            StartTranslationCommand = new LambdaCommand(OnStartTranslationCommandExecuted, CanStartTranslationCommandExecute);

            HistoryVM = new TranslationHistoryViewModel();
            TranslateVM = new TranslationControlViewModel();

            SelectedViewModel = TranslateVM;
        }
    }
}
