namespace SourceCodeGenerator
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Editing;
    using Microsoft.CodeAnalysis.Formatting;

    public static class FileMerger
    {
        public static async Task MergeFiles(Document rootDoc, IEnumerable<Document> docs, string outputPath)
        {
            DocumentEditor de = await DocumentEditor.CreateAsync(rootDoc);

            // Merge other files into the document
            var compilationNode = de.OriginalRoot.ChildNodes().First(); // CompilationUnit
            var node = compilationNode.ChildNodes().Last();
            foreach (var doc in docs)
            {
                var refRoot = await doc.GetSyntaxRootAsync();
                var refCompilationNode = refRoot.ChildNodes().First();
                foreach (var refNode in refCompilationNode.ChildNodes())
                {
                    if (refNode is ClassDeclarationSyntax ||
                        refNode is InterfaceDeclarationSyntax || 
                        refNode is EnumDeclarationSyntax)
                    {
                        de.InsertAfter(node, refNode);
                    }
                }
            }

            // Only keep class Solution, Remove class Problemxxxx
            var outterClass = compilationNode.ChildNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            var innerClass = outterClass.ChildNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            de.ReplaceNode(outterClass, innerClass);

            // Format the final result
            var formatedRoot = Formatter.Format(de.GetChangedRoot(), rootDoc.Project.Solution.Workspace);
            using (StreamWriter writer = File.CreateText(outputPath))
            {
                formatedRoot.WriteTo(writer);
            }
        }
    }
}
