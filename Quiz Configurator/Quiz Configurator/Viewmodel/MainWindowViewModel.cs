using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.View;
using Quiz_Configurator.Windows;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_Configurator.Viewmodel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionPackViewModel> Packs { get; set; }
        public PlayerViewModel PlayerViewModel { get; }
        public ConfigurationViewModel ConfigurationViewModel { get; }

        public Save save;
        public Load load;
        public Import import;


        public DelegateCommand NewPackCommand { get; }
        public DelegateCommand SetActivePackCommand { get; }
        public DelegateCommand DeletePackCommand { get; }

        public DelegateCommand SaveOnCloseCommand { get; }
        public DelegateCommand ImportFromDBCommand { get; }
        public DelegateCommand ImportMenuCommand { get; }
        public DelegateCommand ExitCommand { get; }


        public DelegateCommand SetPlayerViewCommand { get; }
        public DelegateCommand SetConfigViewCommand { get; }




        private QuestionPackViewModel? _activePack;

        public ObservableCollection<Category> CategoriesList { get; set; }

        public QuestionPackViewModel? ActivePack
        {
            get => _activePack;
            set
            {
                _activePack = value;
                RaiseProperyChanged();
                ConfigurationViewModel?.RaiseProperyChanged("ActivePack");
            }
        }




        //Import

        private string _downloadDifficulty = "medium";
        public string DownloadDifficulty
        {
            get
            {
                return _downloadDifficulty;
            }
            set
            {
                _downloadDifficulty = value.ToLower();

                RaiseProperyChanged("Difficulty");
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {

                _selectedCategory = value;

                Category = _selectedCategory?.id ?? 9;

                RaiseProperyChanged("SelectedCategory");
            }
        }

        private int _category = 9;
        public int Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                RaiseProperyChanged("Category");
            }
        }

        private int _numberOfQuestions = 10;
        public int NumberOfQuestions
        {
            get
            {
                return _numberOfQuestions;
            }
            set
            {
                _numberOfQuestions = value;

                RaiseProperyChanged("NumberOfQuestions");
            }
        }

        // Visibility

        private Visibility _playerVisibility;
        public Visibility PlayerVisibility
        {
            get
            {
                return _playerVisibility;
            }
            set
            {
                _playerVisibility = value;

                RaiseProperyChanged("PlayerVisibility");
            }
        }

        private Visibility configVisibility;
        public Visibility ConfigVisibility
        {
            get
            {
                return configVisibility;
            }
            set
            {
                configVisibility = value;

                RaiseProperyChanged("ConfigVisibility");
            }
        }


        // Add Pack


        private Difficulty _packDifficulty;
        public Difficulty PackDifficulty
        {
            get
            {
                return _packDifficulty;
            }
            set
            {
                _packDifficulty = value;

                RaiseProperyChanged("PackDifficulty");
            }
        }

        private string _packName = "<PackName>";
        public string PackName
        {
            get
            {
                return _packName;
            }
            set
            {
                _packName = value;

                RaiseProperyChanged("PackName");
            }
        }

        private int _packTimeLimit = 30;
        public int PackTimeLimit
        {
            get
            {
                return _packTimeLimit;
            }
            set
            {
                _packTimeLimit = value;

                RaiseProperyChanged("PackTimeLimit");
            }
        }

        public MainWindowViewModel()
        {
            load = new Load();
            save = new Save();
            import = new Import();
            CategoriesList = new ObservableCollection<Category>();
            GetCategorys();
            LoadAsync();



            NewPackCommand = new DelegateCommand(AddPack);
            SetActivePackCommand = new DelegateCommand(SetActivePack);
            DeletePackCommand = new DelegateCommand(DeleteActivePack);
            SetPlayerViewCommand = new DelegateCommand(SetPlayerView);
            SetConfigViewCommand = new DelegateCommand(SetConfigView);

            SaveOnCloseCommand = new DelegateCommand(SaveOnClose);
            ImportFromDBCommand = new DelegateCommand(async _ => await GetQuestions(ActivePack), _ => true);
            ImportMenuCommand = new DelegateCommand(ImportMenu);
            ExitCommand = new DelegateCommand(Exit);

            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;


            

            PlayerViewModel = new PlayerViewModel(this);
            ConfigurationViewModel = new ConfigurationViewModel(this);
        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void SaveOnClose(object obj)
        {
            save.SaveData(Packs);
        }

        private void DeleteActivePack(object obj)
        {
            Packs?.Remove(ActivePack);
            ActivePack = null;
            save.SaveData(Packs);
        }

        private void SetConfigView(object obj)
        {
            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;
            PlayerViewModel.StopTimer();

            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
        }

        private void SetPlayerView(object obj)
        {
            ConfigVisibility = Visibility.Hidden;
            PlayerVisibility = Visibility.Visible;
            PlayerViewModel.CurrentAmountOfQuestions = ActivePack.Questions.Count();
            PlayerViewModel.StartGame();

            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
        }

        private void SetActivePack(object obj)
        {
            if (obj is QuestionPackViewModel selectedPack)
            {
                ActivePack = selectedPack;
                PlayerViewModel.SetTimerValue();

                RaiseProperyChanged(nameof(ActivePack));  
            }
        }

        private void AddPack(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new CreateNewPackDialog() { DataContext = this };
            var result = createNewPackDialog.ShowDialog();



            if (result == true)
            {
                QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack(PackName, PackDifficulty, PackTimeLimit));
                ActivePack = qp;
                Packs.Add(qp);
                save.SaveData(Packs);
            }

        }


        private async void ImportMenu(object obj)
        {
            _selectedCategory = CategoriesList[0];

            ImportQuestions createNewImportDialog = new ImportQuestions() {DataContext = this};
            var result = createNewImportDialog.ShowDialog();



            if (result == true)
            {
                await GetQuestions(ActivePack, NumberOfQuestions, Category, DownloadDifficulty);   
            }
        }
       


        public async Task LoadAsync()
        {
            var loadedPacks = await load.LoadData();

            if (loadedPacks.Count > 0)
            {
                Packs = loadedPacks;
                ActivePack = Packs[0];
            }
            else
            {
                Packs = new ObservableCollection<QuestionPackViewModel>();
                QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack("My Question pack"));
                Packs.Add(qp);
                ActivePack = qp;
            }
        }



        public static async Task GetQuestions(QuestionPackViewModel? ActivePack, int amount = 10, int category = 9, string difficulty = "medium" )
        {
            Import import = new Import();
            string questions = await import.ImportAsync(amount,category,difficulty);

            if (questions != null)
            {
                var quizResponse = JsonSerializer.Deserialize<ImportClass>(questions);
                
                if (quizResponse != null && quizResponse.Results != null && ActivePack?.Questions != null)
                {
                    foreach (var question in quizResponse.Results)
                    {
                        question.Query = HttpUtility.HtmlDecode(question.Query);
                        question.CorrectAnswer = HttpUtility.HtmlDecode(question.CorrectAnswer);
                        question.IncorrectAnswers[0] = HttpUtility.HtmlDecode(question.IncorrectAnswers[0]);
                        question.IncorrectAnswers[1] = HttpUtility.HtmlDecode(question.IncorrectAnswers[1]);
                        question.IncorrectAnswers[2] = HttpUtility.HtmlDecode(question.IncorrectAnswers[2]);

                        ActivePack.Questions.Add(question);
                    }
                }
                if (quizResponse.ResponseCode == 0)
                {
                    MessageBox.Show("Returned results successfully.");
                }
                else if (quizResponse.ResponseCode == 1)
                {
                    MessageBox.Show("The API doesn't have enough questions for your query. (Ex. Asking for 20 Questions in a Category that only has 10.)");
                }
                else
                {
                    MessageBox.Show($"{quizResponse.ResponseCode} Huh?");
                }
            }
        }


        public async Task GetCategorys()
        {
            Import import = new Import();
            string triviaCategories = await import.ImportCategorysAsync();

            if (triviaCategories != null)
            {
                var categoryResponse = JsonSerializer.Deserialize<TriviaCategories>(triviaCategories);

                CategoriesList.Clear();

                foreach (var category in categoryResponse.triviaCategories)
                {
                    CategoriesList.Add(category);
                }

            }
        }

    }
}
