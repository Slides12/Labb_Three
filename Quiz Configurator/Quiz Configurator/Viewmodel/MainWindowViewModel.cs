using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
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
        public DelegateCommand SetActiveWindowCommand { get; }
        public DelegateCommand SetActivePackCommand { get; }






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

        private Visibility _visibility;
        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;

                RaiseProperyChanged("Visibility");
            }
        }

        private Visibility _visibility1;
        public Visibility Visibility1
        {
            get
            {
                return _visibility1;
            }
            set
            {
                _visibility1 = value;

                RaiseProperyChanged("Visibility1");
            }
        }

        public MainWindowViewModel()
        {
            Packs = new ObservableCollection<QuestionPackViewModel>();
            NewPackCommand = new DelegateCommand(AddPack);
            SetActivePackCommand = new DelegateCommand(SetActivePack);
            SetActiveWindowCommand = new DelegateCommand(SetActiveWindow);



            QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack("My Question pack"));
            Packs.Add(qp);
            ActivePack = qp;


            PlayerViewModel = new PlayerViewModel(this);

            ConfigurationViewModel = new ConfigurationViewModel(this);
        }

        private void SetActiveWindow(object obj)
        {
            Visibility = Visibility.Hidden;
            RaiseProperyChanged();
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
