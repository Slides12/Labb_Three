using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;


namespace Quiz_Configurator.Viewmodel
{
    class PlayerViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public DelegateCommand CheckButtonCommand { get; }
        private int secondsOnly;
        private bool canPress = true;


        private int _points;
        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;

                RaiseProperyChanged("Points");
            }
        }


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
        private string _seconds;
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
                _query = value;

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
                _correctQuestion = value;

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
                _wrongQuestion1 = value;

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
                _wrongQuestion2 = value;

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
                _wrongQuestion3 = value;

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
        TimeSpan time;

        public PlayerViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            CheckButtonCommand = new DelegateCommand(CheckButton);
            SetTimerValue();
        }

        private async void CheckButton(object obj)
        {
            if (obj is System.Windows.Controls.Button button)
            {
                if (canPress) 
                { 
                    if((button.Content as TextBlock).Text.Equals(ActivePack.Questions[Index - 1].CorrectAnswer))
                    {
                        button.Background = new SolidColorBrush(Colors.LightGreen);
                        canPress = false;
                        Points++;
                        await Task.Delay(1500);
                        button.Background = new SolidColorBrush(Colors.White);
                        NextQuestion();
                        canPress = true;
                    }
                    else
                    {
                        button.Background = new SolidColorBrush(Colors.IndianRed);
                        canPress = false;
                        await Task.Delay(1500);
                        button.Background = new SolidColorBrush(Colors.White);
                        NextQuestion();
                        canPress = true;
                    }
                }
            }
        }

        private void NextQuestion()
        {
            if (Index < CurrentAmountOfQuestions)
            {
                Index++;
                UpdateQuestions();
                SetTimerValue();
            }
            else
            {
                mainWindowViewModel.SetEndScreen();
            }
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
                        mainWindowViewModel.SetEndScreen();
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
            Points = 0;
            UpdateQuestions();
            SetTimerValue();
            StartTimer();
        }

        public List<string> SetQuestionsRandomly(string correct, string wrong1, string wrong2, string wrong3)
        {
            string[] strings = new string[4] {correct,wrong1,wrong2,wrong3};

            Random rng = new Random();

            var randomizeQuestions = strings.OrderBy(_ => rng.Next()).ToList();

            return randomizeQuestions;
        }

        private void UpdateQuestions()
        {
            List<string> strings = SetQuestionsRandomly(ActivePack.Questions[Index - 1].CorrectAnswer, ActivePack.Questions[Index - 1].IncorrectAnswers[0], ActivePack.Questions[Index - 1].IncorrectAnswers[1], ActivePack.Questions[Index - 1].IncorrectAnswers[2]);

            if (ActivePack != null && ActivePack.Questions.Count > 0) 
            { 
            Query = ActivePack.Questions[Index - 1].Query;
            CorrectQuestion = strings[0];
            WrongQuestion1 = strings[1];
            WrongQuestion2 = strings[2];
            WrongQuestion3 = strings[3];
            }
        }
        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
