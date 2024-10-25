using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.View;

namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel mainWindowViewModel;
        public ConfigurationView configurationView { get; }

        public DelegateCommand NewQuestionCommand { get; }


        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            NewQuestionCommand = new DelegateCommand(NewQuestionButton);
            configurationView = new ConfigurationView();

        }

        private void NewQuestionButton(object obj)
        {
            ActivePack?.Questions.Add(new Question(configurationView.questionTextBox.Text, configurationView.correctQTextBox.Text, configurationView.wrong1TextBox.Text, configurationView.wrong2TextBox.Text, configurationView.wrong3TextBox.Text));
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
