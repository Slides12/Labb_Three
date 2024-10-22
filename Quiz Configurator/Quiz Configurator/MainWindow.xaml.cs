using Quiz_Configurator.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Configurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newQPMenu_Click(object sender, RoutedEventArgs e)
        {
            NewPack np = new NewPack();
            np.ShowDialog();
        }

        private void packOptionsMenu_Click(object sender, RoutedEventArgs e)
        {
            PackOptions packOptions = new PackOptions();
            packOptions.ShowDialog();
        }

        private void importantQuestionsMenu_Click(object sender, RoutedEventArgs e)
        {
            ImportQuestions importQuestions = new ImportQuestions();
            importQuestions.ShowDialog();
        }
    }
}