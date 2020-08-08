using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCDMS
{
    public class DocumentsManager
    {
        private List<string> _documents;
        public DocumentsManager(List<string> documents)
        {
            _documents = documents;
        }

        public string Add(string level1, string level2, string level3, string level4, string level5)
        {
            StringBuilder fileName = new StringBuilder();
            fileName.Append($"{level1}-{level2}-{level3}-{level4}-{level5}-");

            var results = _documents.Where(x => x.Contains(fileName.ToString()));
            int seq = results.Count() + 1;

            fileName.Append(seq.ToString("D4"));

            _documents.Add(fileName.ToString());

            return fileName.ToString();
        }
    }
}
