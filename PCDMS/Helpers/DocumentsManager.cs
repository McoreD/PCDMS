using System.Linq;
using System.Text;

namespace PCDMS
{
    public class DocumentsManager
    {

        public DocumentsManager()
        {

        }

        public void Add(string level1, string level2, string level3, string level4, string level5, string fileName, string fileType)
        {
            StringBuilder sbCode = new StringBuilder();
            sbCode.Append($"{level1}-{level2}-{level3}-{level4}-{level5}-");

            var results = App.Settings.DocumentsList.Where(x => x.FileName.Contains(sbCode.ToString()));
            int seq = results.Count() + 1;

            sbCode.Append(seq.ToString("D4"));


            App.Settings.DocumentsList.Add(new DocInfo()
            {
                FileName = $"{sbCode} {fileName}",
                FileType = fileType
            });
        }
    }
}
