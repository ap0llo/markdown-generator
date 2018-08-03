using System.Linq;
using Grynwald.Utilities.Collections;
using Microsoft.CodeAnalysis;
using Xunit.Sdk;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    internal static class CompilationAssert
    {
        public static void NoErrors(Compilation compilation)
        {
            var errors = compilation.GetDiagnostics()
                .Where(d => d.Severity >= DiagnosticSeverity.Error || d.IsWarningAsError)
                .ToArray();
            
            if (errors.Length > 0)
            {
                throw new XunitException(
                    "Compliation contains errors:\r\n" +
                    errors.Select(x => "  " + x.ToString()).JoinToString("\r\n")
                );
            }
        }
    }
}
