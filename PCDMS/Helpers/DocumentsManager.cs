using System.Linq;
using System.Text;

namespace PCDMS
{
    public class DocumentsManager
    {

        public void Add(string level1, string level2, string level3, string level4, string level5, DocInfo docInfo)
        {
            StringBuilder sbCode = new StringBuilder();
            sbCode.Append($"{level1}-{level2}-{level3}-{level4}-{level5}-");

            var results = App.Settings.DocumentsList.Where(x => x.Name.Contains(sbCode.ToString()));
            int seq = results.Count() + 1;

            sbCode.Append(seq.ToString("D4"));

            if (string.IsNullOrEmpty(docInfo.Name))
                docInfo.Name = $"New {docInfo.Type}";

            docInfo.Name = $"{sbCode} {docInfo.Name}";

            App.Settings.DocumentsList.Add(docInfo);
        }
    }
}
