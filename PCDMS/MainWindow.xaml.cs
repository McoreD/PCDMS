using System.Reflection;
using System.Windows;

namespace PCDMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SettingsViewModel _settings = new SettingsViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _settings;

            Title = $"PCDMS Mockup {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            cboLevel1.SelectedIndex = 0;
            cboLevel2.SelectedIndex = 0;
            cboLevel3.SelectedIndex = 0;
            cboLevel4.SelectedIndex = 0;
            cboLevel5.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            DocumentsManager doc = new DocumentsManager(_settings.DocumentsList);
            NamingData data1 = cboLevel1.SelectedItem as NamingData;
            NamingData data2 = cboLevel2.SelectedItem as NamingData;
            NamingData data3 = cboLevel3.SelectedItem as NamingData;
            NamingData data4 = cboLevel4.SelectedItem as NamingData;
            NamingData data5 = cboLevel5.SelectedItem as NamingData;

            txtFileName.Text = doc.Add(data1.Code, data2.Code, data3.Code, data4.Code, data5.Code);
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtFileName.Text);
        }

        private void cboLevel_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            txtFileName.Clear();
        }
    }
}
