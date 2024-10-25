using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.Windows;
using System.Collections.ObjectModel;

namespace Quiz_Configurator.Viewmodel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionPackViewModel> Packs { get; set; }
        public PlayerViewModel PlayerViewModel { get; }
        public ConfigurationViewModel ConfigurationViewModel { get; }

        public DelegateCommand NewPackCommand { get; }
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

        public MainWindowViewModel()
        {
            Packs = new ObservableCollection<QuestionPackViewModel>();
            NewPackCommand = new DelegateCommand(AddPack);
            SetActivePackCommand = new DelegateCommand(SetActivePack);

            QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack("My Question pack"));
            Packs.Add(qp);
            ActivePack = qp;//Skall inte sättas här sen, skall sätta den aktiva packen, inte "My question Pack"


            PlayerViewModel = new PlayerViewModel(this);

            ConfigurationViewModel = new ConfigurationViewModel(this);
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
