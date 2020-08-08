using System.Linq;
using System.Text;

namespace PCDMS
{
    public class DocumentsManager
    {

        public DocumentsManager()
        {

        }

        public string Add(string level1, string level2, string level3, string level4, string level5, string fileType)
        {
            StringBuilder fileName = new StringBuilder();
            fileName.Append($"{level1}-{level2}-{level3}-{level4}-{level5}-");

            var results = App.Settings.DocumentsList.Where(x => x.FileName.Contains(fileName.ToString()));
            int seq = results.Count() + 1;

            fileName.Append(seq.ToString("D4"));


            App.Settings.DocumentsList.Add(new DocInfo()
            {
                FileName = fileName.ToString(),
                FileType = fileType
            });

            return fileName.ToString();
        }
    }
}
