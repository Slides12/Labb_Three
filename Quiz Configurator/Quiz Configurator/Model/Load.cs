using Quiz_Configurator.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model
{
    internal class Load
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public ObservableCollection<QuestionPackViewModel> LoadData()
        {
            string directoryPath = Path.Combine(path, "QuizConfigurator");
            string filePath = Path.Combine(directoryPath, "QuizConfig.json");
            ObservableCollection<QuestionPackViewModel> Packs = new ObservableCollection<QuestionPackViewModel>();

            

            if (Directory.Exists(directoryPath) && File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string jsonContent = sr.ReadToEnd();
                    var questionPacks = JsonSerializer.Deserialize<List<QuestionPack>>(jsonContent);

                    if (questionPacks != null)
                    {
                        foreach (var questionPack in questionPacks)
                        {
                            Packs.Add(new QuestionPackViewModel(questionPack));
                        }
                    }
                }
            }

            return Packs;
        }
    }
}
