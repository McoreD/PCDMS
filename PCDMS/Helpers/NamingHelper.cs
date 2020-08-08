using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PCDMS
{
    public class NamingHelper
    {
        private string _filePath = "fnc.csv";
        private List<NamingData> _codes;

        public List<NamingData> Level1 { get; private set; } = new List<NamingData>();
        public List<NamingData> Level2 { get; private set; } = new List<NamingData>();
        public List<NamingData> Level3 { get; private set; } = new List<NamingData>();
        public List<NamingData> Level4 { get; private set; } = new List<NamingData>();
        public List<NamingData> Level5 { get; private set; } = new List<NamingData>();

        public NamingHelper()
        {
            if (File.Exists(_filePath))
                _codes = File.ReadAllLines(_filePath).Skip(1).Select(v => NamingData.FromCsv(v)).ToList();

            if (_codes.Count > 0)
            {
                Level1.AddRange(_codes.Where(x => x.Level == 1).ToList());
                Level2.AddRange(_codes.Where(x => x.Level == 2).ToList());
                Level3.AddRange(_codes.Where(x => x.Level == 3).ToList());
                Level4.AddRange(_codes.Where(x => x.Level == 4).ToList());
                Level5.AddRange(_codes.Where(x => x.Level == 5).ToList());
            }
        }
    }

    public class NamingData
    {
        public int Level { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }

        public static NamingData FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            NamingData data = new NamingData();

            data.Level = Convert.ToInt32(values[0]);
            data.Code = values[1];
            data.Description = values[2];

            return data;
        }

        public override string ToString()
        {
            return $"{Code} - {Description}";
        }
    }
}
