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

        public List<NamingData> Level1;
        public List<NamingData> Level2;
        public List<NamingData> Level3;
        public List<NamingData> Level4;
        public List<NamingData> Level5;

        public NamingHelper()
        {
            if (File.Exists(_filePath))
                _codes = File.ReadAllLines(_filePath).Skip(1).Select(v => NamingData.FromCsv(v)).ToList();

            if (_codes.Count > 0)
            {
                foreach (NamingData data in _codes)
                {
                    switch (data.Level)
                    {
                        case 1:
                            Level1.Add(data);
                            break;
                        case 2:
                            Level2.Add(data);
                            break;
                        case 3:
                            Level3.Add(data);
                            break;
                        case 4:
                            Level4.Add(data);
                            break;
                        case 5:
                            Level5.Add(data);
                            break;
                    }
                }
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
