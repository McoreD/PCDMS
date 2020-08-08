using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PCDMS
{
    public class SettingsViewModel
    {
        public List<NamingData> Level1 { get; set; }
        public List<NamingData> Level2 { get; set; }
        public List<NamingData> Level3 { get; set; }
        public List<NamingData> Level4 { get; set; }
        public List<NamingData> Level5 { get; set; }

        public ObservableCollection<DocInfo> DocumentsList { get; set; } = new ObservableCollection<DocInfo>();

        public SettingsViewModel()
        {
            NamingHelper helper = new NamingHelper();
            Level1 = helper.Level1;
            Level2 = helper.Level2;
            Level3 = helper.Level3;
            Level4 = helper.Level4;
            Level5 = helper.Level5;
        }
    }
}
