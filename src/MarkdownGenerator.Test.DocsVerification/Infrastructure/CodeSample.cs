using System;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    public class CodeSample
    {
        public string RelativePath { get; }

        public string SourceCode { get; }

        public int Line { get; }


        public CodeSample(string relativePath, int line, string code)
        {
            if (String.IsNullOrEmpty(relativePath))
                throw new ArgumentException("Value must not be empty", nameof(relativePath));

            RelativePath = relativePath;
            Line = line;
            SourceCode = code ?? throw new ArgumentNullException(nameof(code));
        }


        // line is zero based, convet ot one-based line index for user-visible string
        public override string ToString() => $"{RelativePath}, line {Line + 1}";            
    }
}
