using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using System;
using System.Diagnostics;
using System.Web;
using System.Windows.Threading;

namespace Quiz_Configurator.Viewmodel
{
    class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public DelegateCommand UpdateButtonCommand { get; }
        private int secondsOnly;
        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;

                RaiseProperyChanged("Index");
            }
        }
        public string Seconds
        {
            get => _seconds;
            private set
            {
                _seconds = value;
                RaiseProperyChanged();
            }
        }
        private string _query;
        public string Query
        {
            get
            {
                return _query;
            }
            set
            {
                _query = HttpUtility.UrlDecode(value);

                RaiseProperyChanged("Query");
            }
        }

        private string _correctQuestion;
        public string CorrectQuestion
        {
            get
            {
                return _correctQuestion;
            }
            set
            {
                _correctQuestion = HttpUtility.UrlDecode(value);

                RaiseProperyChanged("CorrectQuestion");
            }
        }

        private string _wrongQuestion1;
        public string WrongQuestion1
        {
            get
            {
                return _wrongQuestion1;
            }
            set
            {
                _wrongQuestion1 = HttpUtility.UrlDecode(value);

                RaiseProperyChanged("WrongQuestion1");
            }
        }
        
        private string _wrongQuestion2;
        public string WrongQuestion2
        {
            get
            {
                return _wrongQuestion2;
            }
            set
            {
                _wrongQuestion2 = HttpUtility.UrlDecode(value);

                RaiseProperyChanged("WrongQuestion2");
            }
        }
        
        private string _wrongQuestion3;
        public string WrongQuestion3
        {
            get
            {
                return _wrongQuestion3;
            }
            set
            {
                _wrongQuestion3 = HttpUtility.UrlDecode(value);

                RaiseProperyChanged("WrongQuestion3");
            }
        }
        
        private int _currentAmountOfQuestions;
        public int CurrentAmountOfQuestions
        {
            get
            {
                return _currentAmountOfQuestions;
            }
            set
            {
                _currentAmountOfQuestions = value;

                RaiseProperyChanged("CurrentAmountOfQuestions");
            }
        }






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
            if (Index <= CurrentAmountOfQuestions)
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                int secondsOnly = (int)time.TotalSeconds;
                Seconds = secondsOnly.ToString();
                if(secondsOnly <= 0)
                {
                    if (Index < CurrentAmountOfQuestions) 
                    {
                        Index++;
                        UpdateQuestions();
                        SetTimerValue();
                    }
                    else
                    {
                        StopTimer();
                    }
                }
            }
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
            if(ActivePack != null) { 
            time = TimeSpan.FromSeconds(ActivePack.TimeLimitInSeconds);
            secondsOnly = (int)time.TotalSeconds;
            Seconds = secondsOnly.ToString();
            }
        }

        public void StartGame()
        {
            Index = 1;
            UpdateQuestions();
            SetTimerValue();
            StartTimer();
        }


        private void UpdateQuestions()
        {
            if(ActivePack != null && ActivePack.Questions.Count > 0) 
            { 
            Query = ActivePack.Questions[Index - 1].Query;
            CorrectQuestion = ActivePack.Questions[Index - 1].CorrectAnswer;
            WrongQuestion1 = ActivePack.Questions[Index - 1].IncorrectAnswers[0];
            WrongQuestion2 = ActivePack.Questions[Index - 1].IncorrectAnswers[1];
            WrongQuestion3 = ActivePack.Questions[Index - 1].IncorrectAnswers[2];
            }
        }
        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
