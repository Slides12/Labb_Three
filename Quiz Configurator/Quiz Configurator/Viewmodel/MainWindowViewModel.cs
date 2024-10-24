using Quiz_Configurator.Model;
using System.Collections.ObjectModel;

namespace Quiz_Configurator.Viewmodel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionPackViewModel> Packs { get; set; }
        public PlayerViewModel PlayerViewModel { get; }
        public ConfigurationViewModel ConfigurationViewModel { get; }


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
            ActivePack = new QuestionPackViewModel(new QuestionPack("My Question pack")); //Skall inte sättas här sen, skall sätta den aktiva packen, inte "My question Pack"

            PlayerViewModel = new PlayerViewModel(this);
            ConfigurationViewModel = new ConfigurationViewModel(this);
        }
    }
}
