using Quiz_Configurator.Command;
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



        public DelegateCommand NewPackCommand { get; }
        public DelegateCommand SetActivePackCommand { get; }


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
            Packs = new ObservableCollection<QuestionPackViewModel>();
            NewPackCommand = new DelegateCommand(AddPack);
            SetActivePackCommand = new DelegateCommand(SetActivePack);
            SetPlayerViewCommand = new DelegateCommand(SetPlayerView);
            SetConfigViewCommand = new DelegateCommand(SetConfigView);

            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;

            QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack("My Question pack"));
            Packs.Add(qp);
            ActivePack = qp;


            PlayerViewModel = new PlayerViewModel(this);

            ConfigurationViewModel = new ConfigurationViewModel(this);
        }

        private void SetConfigView(object obj)
        {
            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;
            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
        }

        private void SetPlayerView(object obj)
        {
            ConfigVisibility = Visibility.Hidden;
            PlayerVisibility = Visibility.Visible;
            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
        }

        private void SetActivePack(object obj)
        {
            if (obj is QuestionPackViewModel selectedPack)
            {
                ActivePack = selectedPack;
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
            }
        }

    }
}
