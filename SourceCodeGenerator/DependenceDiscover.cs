namespace SourceCodeGenerator
{
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class DependenceDiscover
    {
        public static async Task<HashSet<string>> GetDependences(FilePathMapping mapping)
        {
            HashSet<string> dependences = new HashSet<string>();
            await GetDependences(mapping, dependences, mapping.SourceFileDocument.FilePath);
            dependences.Remove(mapping.SourceFileDocument.FilePath); // remove root file
            return dependences;
        }

        private static async Task GetDependences(FilePathMapping mapping, HashSet<string> refs, string filePath)
        {
            if (!mapping.IsReference(filePath))
            {
                return;
            }

            // Add file itself
            refs.Add(filePath);

            SemanticModel model = await mapping.GetRefDocument(filePath).GetSemanticModelAsync();
            foreach (var node in model.SyntaxTree.GetRoot().DescendantNodes())
            {
                var typeSymbol = GetTypeSymbol(model, node);
                var refFilePath = GetReferenceSourceFilePath(typeSymbol);
                if (!string.IsNullOrEmpty(refFilePath) && !refs.Contains(refFilePath))
                {
                    // If ref file is not null and not included in the hash set
                    await GetDependences(mapping, refs, refFilePath);
                }
            }
        }

        private static ITypeSymbol GetTypeSymbol(SemanticModel model, SyntaxNode node)
        {
            switch (node)
            {
                case VariableDeclarationSyntax variableDeclarationSyntax:
                    // Get variable type
                    var typeInfo = model.GetTypeInfo(variableDeclarationSyntax.Type);
                    return typeInfo.Type;

                case InvocationExpressionSyntax:
                case MemberAccessExpressionSyntax:
                    // Method invocation
                    var symbolInfo = model.GetSymbolInfo(node);
                    return symbolInfo.Symbol?.ContainingType;

                case ParameterSyntax:
                    // Get parameter type
                    var declaredSymbol = model.GetDeclaredSymbol(node) as IParameterSymbol;
                    return declaredSymbol.Type;

                default:
                    return null;
            }
        }

        private static string GetReferenceSourceFilePath(ITypeSymbol typeSymbol)
        {
            if (typeSymbol == null)
            {
                return null;
            }

            // TODO: Also need to handle other specific TypeKind here
            if (typeSymbol.TypeKind == TypeKind.Array)
            {
                return GetReferenceSourceFilePath(typeSymbol.BaseType);
            }

            var location = typeSymbol.Locations.FirstOrDefault();
            if (location != null && location.Kind == LocationKind.SourceFile)
            {
                // If this type is defined by source code, need to merge them
                return location.SourceTree.FilePath;
            }

            return null;
        }
    }
}