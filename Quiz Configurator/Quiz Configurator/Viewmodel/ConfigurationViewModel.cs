namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel mainWindowViewModel;


        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
