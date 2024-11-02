using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;
using System.Windows.Documents;
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

        public DelegateCommand CheckButtonCommand1 { get; }
        public DelegateCommand CheckButtonCommand2 { get; }
        public DelegateCommand CheckButtonCommand3 { get; }
        public DelegateCommand CheckButtonCommand4 { get; }
        private int secondsOnly;
        private bool canPress = true;
        private bool nextQuestion = false;

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

        private string _question1;
        public string Question1
        {
            get
            {
                return _question1;
            }
            set
            {
                _question1 = value;

                RaiseProperyChanged("Question1");
            }
        }

        private string _question2;
        public string Question2
        {
            get
            {
                return _question2;
            }
            set
            {
                _question2 = value;

                RaiseProperyChanged("Question2");
            }
        }
        
        private string _question3;
        public string Question3
        {
            get
            {
                return _question3;
            }
            set
            {
                _question3 = value;

                RaiseProperyChanged("Question3");
            }
        }
        
        private string _question4;
        public string Question4
        {
            get
            {
                return _question4;
            }
            set
            {
                _question4 = value;

                RaiseProperyChanged("Question4");
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

        private SolidColorBrush _questionColor1;
        public SolidColorBrush QuestionColor1
        {
            get
            {
                return _questionColor1;
            }
            set
            {
                _questionColor1 = value;

                RaiseProperyChanged("QuestionColor1");
            }
        }

        private SolidColorBrush _questionColor2;
        public SolidColorBrush QuestionColor2
        {
            get
            {
                return _questionColor2;
            }
            set
            {
                _questionColor2 = value;

                RaiseProperyChanged("QuestionColor2");
            }
        }

        private SolidColorBrush _questionColor3;
        public SolidColorBrush QuestionColor3
        {
            get
            {
                return _questionColor3;
            }
            set
            {
                _questionColor3 = value;

                RaiseProperyChanged("QuestionColor3");
            }
        }

        private SolidColorBrush _questionColor4;
        public SolidColorBrush QuestionColor4
        {
            get
            {
                return _questionColor4;
            }
            set
            {
                _questionColor4 = value;

                RaiseProperyChanged("QuestionColor4");
            }
        }



        private DispatcherTimer timer;
        TimeSpan time;

        public PlayerViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            CheckButtonCommand1 = new DelegateCommand(CheckButton1);
            CheckButtonCommand2 = new DelegateCommand(CheckButton2);
            CheckButtonCommand3 = new DelegateCommand(CheckButton3);
            CheckButtonCommand4 = new DelegateCommand(CheckButton4);
            SetTimerValue();
        }

        private async void CheckButton1(object obj)
        {
            if (obj is Button button)
            {
                if (canPress) 
                { 
                    if((button.Content as TextBlock).Text.Equals(ActivePack.Questions[Index - 1].CorrectAnswer))
                    {
                        QuestionColor1 = new SolidColorBrush(Colors.LightGreen);
                        canPress = false;
                        Points++;
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                    else
                    {
                        QuestionColor1 = new SolidColorBrush(Colors.IndianRed);
                        canPress = false;
                        HighlightCorrectAnswer();
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                }
            }
        }

        private async void CheckButton2(object obj)
        {
            if (obj is Button button)
            {
                if (canPress)
                {
                    if ((button.Content as TextBlock).Text.Equals(ActivePack.Questions[Index - 1].CorrectAnswer))
                    {
                        QuestionColor2 = new SolidColorBrush(Colors.LightGreen);
                        canPress = false;
                        Points++;
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                    else
                    {
                        QuestionColor2 = new SolidColorBrush(Colors.IndianRed);
                        canPress = false;
                        HighlightCorrectAnswer();
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                }
            }
        }

        private async void CheckButton3(object obj)
        {
            if (obj is Button button)
            {
                if (canPress)
                {
                    if ((button.Content as TextBlock).Text.Equals(ActivePack.Questions[Index - 1].CorrectAnswer))
                    {
                        QuestionColor3 = new SolidColorBrush(Colors.LightGreen);
                        canPress = false;
                        Points++;
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                    else
                    {
                        QuestionColor3 = new SolidColorBrush(Colors.IndianRed);
                        canPress = false;
                        HighlightCorrectAnswer();
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                }
            }
        }

        private async void CheckButton4(object obj)
        {
            if (obj is Button button)
            {
                if (canPress)
                {
                    if ((button.Content as TextBlock).Text.Equals(ActivePack.Questions[Index - 1].CorrectAnswer))
                    {
                        QuestionColor4 = new SolidColorBrush(Colors.LightGreen);
                        canPress = false;
                        Points++;
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                    else
                    {
                        QuestionColor4 = new SolidColorBrush(Colors.IndianRed);
                        canPress = false;
                        HighlightCorrectAnswer();
                        await Task.Delay(1500);
                        ResetAllColors();
                        NextQuestion();
                        canPress = true;
                    }
                }
            }
        }

        private void HighlightCorrectAnswer()
        {
            
                string correctAnswer = ActivePack.Questions[Index - 1].CorrectAnswer;
                if (correctAnswer.Equals(Question1))
                {
                    QuestionColor1 = new SolidColorBrush(Colors.LightGreen);
                }
                else if (correctAnswer.Equals(Question2))
                {
                    QuestionColor2 = new SolidColorBrush(Colors.LightGreen);
                }
                else if (correctAnswer.Equals(Question3))
                {
                    QuestionColor3 = new SolidColorBrush(Colors.LightGreen);
                }
                else if (correctAnswer.Equals(Question4))
                {
                    QuestionColor4 = new SolidColorBrush(Colors.LightGreen);
                }
        }

        private void ResetAllColors()
        {
            QuestionColor1 = new SolidColorBrush(Colors.White);
            QuestionColor2 = new SolidColorBrush(Colors.White);
            QuestionColor3 = new SolidColorBrush(Colors.White);
            QuestionColor4 = new SolidColorBrush(Colors.White);

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

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            if (Index <= CurrentAmountOfQuestions && !nextQuestion)
            {
                nextQuestion = true; // Prevent re-entry
                time = time.Add(TimeSpan.FromSeconds(-1));
                int secondsOnly = (int)time.TotalSeconds;
                Seconds = secondsOnly.ToString();

                if (secondsOnly <= 0)
                {
                    HighlightCorrectAnswer();
                    await Task.Delay(1000);

                    if (Index < CurrentAmountOfQuestions)
                    {
                        Index++;
                        ResetAllColors();
                        UpdateQuestions();
                        SetTimerValue();
                    }
                    else
                    {
                        mainWindowViewModel.SetEndScreen();
                    }
                }

                nextQuestion = false; 
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
            CorrectQuestion = ActivePack.Questions[Index - 1].CorrectAnswer;
            List<string> strings = SetQuestionsRandomly
                (
                CorrectQuestion, 
                ActivePack.Questions[Index - 1].IncorrectAnswers[0], 
                ActivePack.Questions[Index - 1].IncorrectAnswers[1], 
                ActivePack.Questions[Index - 1].IncorrectAnswers[2]
                );



            if (ActivePack != null && ActivePack.Questions.Count > 0) 
            { 
            Query = ActivePack.Questions[Index - 1].Query;
            Question1 = strings[0];
            Question2 = strings[1];
            Question3 = strings[2];
            Question4 = strings[3];
            }
        }
        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
