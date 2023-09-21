namespace SourceCodeGenerator
{
    using Microsoft.CodeAnalysis;

    public class FilePathMapping
    {
        private readonly Dictionary<string, Document> refPath2Doc = new Dictionary<string, Document>();

        public Document SourceFileDocument { get; private set; }

        public FilePathMapping(Solution solution, string sourceFilePath, string refProjectPath)
        {
            this.refPath2Doc = new Dictionary<string, Document>();
            foreach (var project in solution.Projects)
            {
                bool isRefProject = PathEquals(refProjectPath, project.FilePath);
                foreach (var doc in project.Documents)
                {
                    if (isRefProject)
                    {
                        this.refPath2Doc.Add(doc.FilePath, doc);
                    }

                    if (PathEquals(sourceFilePath, doc.FilePath))
                    {
                        this.refPath2Doc.Add(doc.FilePath, doc);
                        this.SourceFileDocument = doc;
                    }
                }
            }
        }

        public bool IsReference(string filePath)
        {
            return this.refPath2Doc.ContainsKey(filePath);
        }

        public Document GetRefDocument(string filePath)
        {
            Document doc = null;
            this.refPath2Doc.TryGetValue(filePath, out doc);
            return doc;
        }

        private static bool PathEquals(string filePath1, string filePath2)
        {
            return filePath1.Equals(filePath2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
