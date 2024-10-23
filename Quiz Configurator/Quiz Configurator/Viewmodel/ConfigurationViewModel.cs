namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel
    {
        private readonly MainWindowViewModel mainWindowViewModel;


        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }
    }
}
