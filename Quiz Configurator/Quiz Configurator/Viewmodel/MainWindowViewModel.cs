﻿using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.View;
using Quiz_Configurator.Windows;
using System.Collections.ObjectModel;
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
        public DelegateCommand ExitCommand { get; }


        public DelegateCommand SetPlayerViewCommand { get; }
        public DelegateCommand SetConfigViewCommand { get; }




        private QuestionPackViewModel? _activePack;

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

        public MainWindowViewModel()
        {
            load = new Load();
            save = new Save();
            import = new Import();



            LoadAsync();



             NewPackCommand = new DelegateCommand(AddPack);
            SetActivePackCommand = new DelegateCommand(SetActivePack);
            DeletePackCommand = new DelegateCommand(DeleteActivePack);
            SetPlayerViewCommand = new DelegateCommand(SetPlayerView);
            SetConfigViewCommand = new DelegateCommand(SetConfigView);

            SaveOnCloseCommand = new DelegateCommand(SaveOnClose);
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
            CreateNewPackDialog createNewPackDialog = new CreateNewPackDialog();
            var result = createNewPackDialog.ShowDialog();



            if (result == true)
            {
                QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack(createNewPackDialog.textBox.Text, (Difficulty)createNewPackDialog.comboBox.SelectedValue, (int)createNewPackDialog.slider.Value));
                ActivePack = qp;
                Packs.Add(qp);
                save.SaveData(Packs);
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


        
    }
}
