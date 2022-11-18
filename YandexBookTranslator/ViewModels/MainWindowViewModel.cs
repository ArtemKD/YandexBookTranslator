using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YandexBookTranslator.Infrastructure.Commands;
using YandexBookTranslator.ViewModels.Base;

namespace YandexBookTranslator.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public readonly TranslationHistoryViewModel HistoryVM;
        public readonly TranslationControlViewModel TranslateVM;

        #region SelectViewModel
        private object _SelectedViewModel;
        public object SelectedViewModel
        {
            get => _SelectedViewModel;
            set => Set(ref _SelectedViewModel, value);
        }
        #endregion

        #region Commands
        #region OpenHistoryCommand
        public ICommand OpenHistoryCommand { get; }
        private bool CanOpenHistoryCommandExecute(object p) => true;
        private void OnOpenHistoryCommandExecuted(object p)
        {
            SelectedViewModel = HistoryVM;
        }
        #endregion

        #region OpenTransalteCommand
        public ICommand OpenTransalteCommand { get; }
        private bool CanOpenTransalteCommandExecute(object p) => true;
        private void OnOpenTransalteCommandExecuted(object p)
        {
            SelectedViewModel = TranslateVM;
        }
        #endregion
        #endregion

        public MainWindowViewModel()
        {

            OpenHistoryCommand = new LambdaCommand(OnOpenHistoryCommandExecuted, CanOpenHistoryCommandExecute);
            OpenTransalteCommand = new LambdaCommand(OnOpenTransalteCommandExecuted, CanOpenTransalteCommandExecute);

            HistoryVM = new TranslationHistoryViewModel();
            TranslateVM = new TranslationControlViewModel();
        }
    }
}
