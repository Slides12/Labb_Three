using Quiz_Configurator.Model;
using System.Windows;
using System.Windows.Data;

namespace Quiz_Configurator.Windows
{
    /// <summary>
    /// Interaction logic for PackOptionsDialog.xaml
    /// </summary>
    public partial class PackOptionsDialog : Window
    {
        public PackOptionsDialog()
        {
            InitializeComponent();
            comboBox.ItemsSource = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            comboBox.SelectedIndex = 1;
        }
    }
}
