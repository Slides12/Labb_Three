using Quiz_Configurator.Model;
using System.Windows;

namespace Quiz_Configurator.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewPackDialog.xaml
    /// </summary>
    public partial class CreateNewPackDialog : Window
    {
        public CreateNewPackDialog()
        {
            InitializeComponent();
           
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
