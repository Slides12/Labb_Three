using Quiz_Configurator.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Quiz_Configurator.Model
{
    internal class Save
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public void SaveData(ObservableCollection<QuestionPackViewModel> Packs)
        {
            string directoryPath = Path.Combine(path, "QuizConfigurator");
            string filePath = Path.Combine(directoryPath, "QuizConfig.json");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                string json = JsonSerializer.Serialize(Packs);
                sw.Write(json);
            }
        }
    }
}
