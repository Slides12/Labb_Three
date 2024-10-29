using Quiz_Configurator.Model;
using System.Collections.ObjectModel;

namespace Quiz_Configurator.Viewmodel
{
    class QuestionPackViewModel : ViewModelBase
    {
        private readonly QuestionPack _model;


        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaiseProperyChanged();
            }
        }

        public Difficulty Difficulty
        {
            get => _model.Difficulty;
            set
            {
                _model.Difficulty = value;
                RaiseProperyChanged();
            }
        }

        public int TimeLimitInSeconds
        {
            get => _model.TimeLimitInSeconds;
            set
            {
                _model.TimeLimitInSeconds = value;
                RaiseProperyChanged();
            }
        }

        public ObservableCollection<Question> Questions { get; }


        public QuestionPackViewModel()
        {
            this._model = new QuestionPack(string.Empty);
            this.Questions = new ObservableCollection<Question>();
        }

        public QuestionPackViewModel(QuestionPack model)
        {
            this._model = model;
            this.Questions = new ObservableCollection<Question>(model.Questions);
        }
    }
}
