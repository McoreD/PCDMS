using System;
using System.IO;
using System.Windows;

namespace PCDMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SettingsViewModel Settings;

        public static readonly string PersonalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PCDMS");
        public static string SettingsFilePath
        {
            get
            {
                return Path.Combine(PersonalFolder, "Settings.json");
            }
        }

        public App()
        {
            Settings = SettingsViewModel.Load(SettingsFilePath);
            Settings.LoadCodes();
        }
    }
}
