using Quiz_Configurator.Command;
using Quiz_Configurator.Model;

namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel mainWindowViewModel;
        public DelegateCommand NewQuestionCommand { get; }
        public DelegateCommand DeleteQuestionCommand { get; }
        public DelegateCommand SetActiveQuestionCommand { get; }




        private Question? _activeQuestion;

        public Question? ActiveQuestion
        {
            get => _activeQuestion;
            set
            {
                _activeQuestion = value;
                RaiseProperyChanged();
            }
        }

        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            NewQuestionCommand = new DelegateCommand(NewQuestionButton);
            DeleteQuestionCommand = new DelegateCommand(DeleteQuestionButton);
            SetActiveQuestionCommand = new DelegateCommand(SetActiveQuestion);


        }

        private void SetActiveQuestion(object obj)
        {
            if (obj is Question selectedQuestion)
            {
                ActiveQuestion = selectedQuestion;
                RaiseProperyChanged(nameof(ActiveQuestion));
            }
        }

        private void DeleteQuestionButton(object obj)
        {
            ActivePack?.Questions.Remove(ActiveQuestion);
        }

        private void NewQuestionButton(object obj)
        {
            Question q = new Question("New Question", "", "", "", "");
            ActivePack?.Questions.Add(q);
            ActiveQuestion = q;
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
