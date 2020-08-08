using System.Windows;
using System.Windows.Controls;

namespace PCDMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgDocuments.ItemsSource = App.Settings.DocumentsList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            NewFileDialog dialog = new NewFileDialog(mi.Tag.ToString());
            dialog.ShowDialog();
        }
    }
}
