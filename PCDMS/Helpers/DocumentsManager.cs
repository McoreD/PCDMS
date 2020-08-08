using System.Linq;
using System.Text;

namespace PCDMS
{
    public class DocumentsManager
    {

        public void Add(string level1, string level2, string level3, string level4, string level5, string fileTitle, DocType docType)
        {
            StringBuilder sbCode = new StringBuilder();
            sbCode.Append($"{level1}-{level2}-{level3}-{level4}-{level5}-");

            var results = App.Settings.DocumentsList.Where(x => x.FileName.Contains(sbCode.ToString()));
            int seq = results.Count() + 1;

            sbCode.Append(seq.ToString("D4"));

            if (string.IsNullOrEmpty(fileTitle))
                fileTitle = $"New {docType.Description}";

            App.Settings.DocumentsList.Add(new DocInfo()
            {
                FileName = $"{sbCode} {fileTitle}.{docType.Extension}",
                FileType = docType.Description
            });
        }
    }
}
