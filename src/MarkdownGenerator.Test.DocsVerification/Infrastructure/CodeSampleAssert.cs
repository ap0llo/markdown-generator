using System.Linq;
using Grynwald.Utilities.Collections;
using Microsoft.CodeAnalysis;
using Xunit.Sdk;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    internal static class CodeSampleAssert
    {
        public static void NoCompilationErrors(CodeSample codeSample)
        {
            var compilation = codeSample.GetCompilation();

            var errors = compilation.GetDiagnostics()
                .Where(d => d.Severity >= DiagnosticSeverity.Error || d.IsWarningAsError)
                .ToArray();
            
            string GetDiagnosticMessage(Diagnostic diagnostic)
            {
                // calculate the position of the error in the original input
                // document based on the location of the error wihtin the source code
                // and the location of the source code within the document

                var location = diagnostic.Location.GetMappedLineSpan().StartLinePosition;
                
                // the line of the error wihtin the original markdown document
                // is the line wihtin the source code + the number of lines in 
                // the document before the code block
                var line = location.Line + codeSample.Line;
                
                // both line and character are zero-based, so add 1 to make them one-based in 
                // error message
                return $"{codeSample.RelativePath}({line + 1},{location.Character + 1}): {diagnostic.Id}: {diagnostic.GetMessage()}";
            }

            if (errors.Length > 0)
            {
                throw new XunitException(
                    "Compliation contains errors:\r\n" +
                    errors
                        .Select(GetDiagnosticMessage)
                        .Select(x => "  " + x)
                        .JoinToString("\r\n")
                );
            }
        }

        
    }
}
