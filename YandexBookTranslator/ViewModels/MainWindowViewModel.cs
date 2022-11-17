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
        public readonly InformationViewModel Information;
        public readonly TranslateViewModel Translate;

        #region SelectViewModel
        private object _SelectedViewModel;
        public object SelectedViewModel
        {
            get => _SelectedViewModel;
            set => Set(ref _SelectedViewModel, value);
        }
        #endregion

        #region Commands
        #region OpenInfoCommand
        public ICommand OpenInfoCommand { get; }
        private bool CanOpenInfoCommandExecute(object p) => true;
        private void OnOpenInfoCommandExecuted(object p)
        {
            SelectedViewModel = Information;
        }
        #endregion

        #region OpenTransalteCommand
        public ICommand OpenTransalteCommand { get; }
        private bool CanOpenTransalteCommandExecute(object p) => true;
        private void OnOpenTransalteCommandExecuted(object p)
        {
            SelectedViewModel = Translate;
        }
        #endregion
        #endregion

        public MainWindowViewModel()
        {

            OpenInfoCommand = new LambdaCommand(OnOpenInfoCommandExecuted, CanOpenInfoCommandExecute);
            OpenTransalteCommand = new LambdaCommand(OnOpenTransalteCommandExecuted, CanOpenTransalteCommandExecute);

            Information = new InformationViewModel();
            Translate = new TranslateViewModel();
        }
    }
}
