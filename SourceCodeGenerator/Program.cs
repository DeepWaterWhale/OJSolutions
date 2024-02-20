namespace SourceCodeGenerator
{
    using Microsoft.Build.Locator;
    using Microsoft.CodeAnalysis.MSBuild;

    internal class Program
    {
        private static string CSharpSolutionRelativePath = @"OJSolutions.sln";
        private static string OJSolutionRelativePath = @"LeetCode\TODOs\Weekly385\Problem3044.cs";
        private static string OutputFileRelativePath = @"SourceCodeGenerator\Merged.cs";
        private static string RefProjectRelativePath = @"Shared\Shared.csproj";

        private static void Main(string[] args)
        {
            var currentFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            MSBuildLocator.RegisterDefaults();

            using (var workspace = MSBuildWorkspace.Create())
            {
                // Open solution
                var csharpSolutionPath = Path.Combine(currentFolder, CSharpSolutionRelativePath);
                var solution = workspace.OpenSolutionAsync(csharpSolutionPath).GetAwaiter().GetResult();

                // Find refs
                var ojSolutionPath = Path.Combine(currentFolder, OJSolutionRelativePath);
                var refProjectPath = Path.Combine(currentFolder, RefProjectRelativePath);
                var fileDocMapping = new FilePathMapping(solution, ojSolutionPath, refProjectPath);
                var refs = DependenceDiscover.GetDependences(fileDocMapping).GetAwaiter().GetResult();

                // Merge files
                var outputPath = Path.Combine(currentFolder, OutputFileRelativePath);
                FileMerger.MergeFiles(
                    fileDocMapping.SourceFileDocument,
                    refs.Select(fileDocMapping.GetRefDocument),
                    outputPath).GetAwaiter().GetResult();

                // Console.ReadKey();
            }
        }
    }
}
