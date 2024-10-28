using Quiz_Configurator.Command;
using System.Windows.Threading;

namespace Quiz_Configurator.Viewmodel
{
    class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public DelegateCommand UpdateButtonCommand { get; }
        public int TimerValue { get; private set; }

        public string TestData
        {
            get => _testData;
            private set
            {
                _testData = value;
                RaiseProperyChanged();
            }
        }
        private DispatcherTimer timer;
        private string _testData;

        public PlayerViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            TimerValue = ActivePack.TimeLimitInSeconds;

            TestData = "Star value:";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateButtonCommand = new DelegateCommand(UpdateButton, CanUpdateButton);
        }

        private bool CanUpdateButton(object? arg)
        {
            return TestData.Length < 20;
        }

        private void UpdateButton(object obj)
        {
            TestData += "x";
            UpdateButtonCommand.RaiseCanExecuteChanged();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimerValue--;
            RaiseProperyChanged();
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
