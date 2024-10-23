namespace Quiz_Configurator.Viewmodel
{
    class PlayerViewModel
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public string TestData { get => "This is test data."; }


        public PlayerViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }
    }
}
