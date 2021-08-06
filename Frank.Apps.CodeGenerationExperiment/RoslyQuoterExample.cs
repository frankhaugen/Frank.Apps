
using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Frank.Apps.CodeGenerationExperiment
{
    public class RoslyQuoterExample
    {
        public void Execute()
        {

            /*
            namespace Frank.Libraries.Calculators.FluentCalculation
            {
                public static class FluentCalculator
                {
                    public static int Add(this int source, int value) => source + value;
                }
            }
            */

            var tree = SyntaxTree(
            //CODE FROM ROSLYN QUOTER:
            CompilationUnit()
            .WithMembers(
                SingletonList<MemberDeclarationSyntax>(
                    NamespaceDeclaration(
                        QualifiedName(
                            QualifiedName(
                                QualifiedName(
                                    IdentifierName("Frank"),
                                    IdentifierName("Libraries")),
                                IdentifierName("Calculators")),
                            IdentifierName("FluentCalculation")))
                    .WithMembers(
                        SingletonList<MemberDeclarationSyntax>(
                            ClassDeclaration("FluentCalculator")
                            .WithModifiers(
                                TokenList(
                                    new[]{
                            Token(SyntaxKind.PublicKeyword),
                            Token(SyntaxKind.StaticKeyword)}))
                            .WithMembers(
                                SingletonList<MemberDeclarationSyntax>(
                                    MethodDeclaration(
                                        PredefinedType(
                                            Token(SyntaxKind.IntKeyword)),
                                        Identifier("Add"))
                                    .WithModifiers(
                                        TokenList(
                                            new[]{
                                    Token(SyntaxKind.PublicKeyword),
                                    Token(SyntaxKind.StaticKeyword)}))
                                    .WithParameterList(
                                        ParameterList(
                                            SeparatedList<ParameterSyntax>(
                                                new SyntaxNodeOrToken[]{
                                        Parameter(
                                            Identifier("source"))
                                        .WithModifiers(
                                            TokenList(
                                                Token(SyntaxKind.ThisKeyword)))
                                        .WithType(
                                            PredefinedType(
                                                Token(SyntaxKind.IntKeyword))),
                                        Token(SyntaxKind.CommaToken),
                                        Parameter(
                                            Identifier("value"))
                                        .WithType(
                                            PredefinedType(
                                                Token(SyntaxKind.IntKeyword)))})))
                                    .WithExpressionBody(
                                        ArrowExpressionClause(
                                            BinaryExpression(
                                                SyntaxKind.AddExpression,
                                                IdentifierName("source"),
                                                IdentifierName("value"))))
                                    .WithSemicolonToken(
                                        Token(SyntaxKind.SemicolonToken))))))))
            .NormalizeWhitespace()
            //END
            );

            var refApis = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Select(a => MetadataReference.CreateFromFile(a.Location));

            var compilation = CSharpCompilation.Create("something", new[] { tree }, refApis);
            var diag = compilation.GetDiagnostics().Where(e => e.Severity == DiagnosticSeverity.Error).ToList();

            foreach (var d in diag)
            {
                Console.WriteLine(d);
            }
        }
    }
}
