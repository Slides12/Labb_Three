using Quiz_Configurator.Command;
using Quiz_Configurator.Model;

namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel mainWindowViewModel;
        public DelegateCommand NewQuestionCommand { get; }
        public DelegateCommand DeleteQuestionCommand { get; }



        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            NewQuestionCommand = new DelegateCommand(NewQuestionButton);
            DeleteQuestionCommand = new DelegateCommand(DeleteQuestionButton);

        }

        private void DeleteQuestionButton(object obj)
        {
            ActivePack?.Questions.Remove(ActivePack?.Questions[0]);
        }

        private void NewQuestionButton(object obj)
        {
            ActivePack?.Questions.Add(new Question("New Question", "", "", "", ""));
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
