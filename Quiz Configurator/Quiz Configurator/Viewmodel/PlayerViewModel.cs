using Quiz_Configurator.Command;
using System.Windows.Threading;

namespace Quiz_Configurator.Viewmodel
{
    class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public DelegateCommand UpdateButtonCommand { get; }


        public string Seconds
        {
            get => _seconds;
            private set
            {
                _seconds = value;
                RaiseProperyChanged();
            }
        }

        public string Query { get; set; } = "New Question";
        public string CorrectQuestion { get; set; } = "Correct Question";
        public string WrongQuestion1 { get; set; } = "Wrong Question";
        public string WrongQuestion2 { get; set; } = "Wrong Question";
        public string WrongQuestion3 { get; set; } = "Wrong Question";
        public int CurrentAmountOfQuestions { get; set; }






        private DispatcherTimer timer;
        private string _seconds;
        TimeSpan time;

        public PlayerViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            SetTimerValue();
        }




        private void Timer_Tick(object? sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(-1));
            int secondsOnly = (int)time.TotalSeconds;
            Seconds = secondsOnly.ToString();
            RaiseProperyChanged();
        }

        public void StartTimer()
        {
            time = TimeSpan.FromSeconds(ActivePack.TimeLimitInSeconds);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
            SetTimerValue();
        }

        public void SetTimerValue()
        {
            time = TimeSpan.FromSeconds(ActivePack.TimeLimitInSeconds);
            int secondsOnly = (int)time.TotalSeconds;
            Seconds = secondsOnly.ToString();
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
