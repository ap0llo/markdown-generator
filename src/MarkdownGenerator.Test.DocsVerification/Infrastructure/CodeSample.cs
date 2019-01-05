using System;
using Xunit.Abstractions;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    public sealed class CodeSample : IXunitSerializable
    {
        public string RelativePath { get; private set; }

        public string SourceCode { get; private set; }

        public int Line { get; private set; }


        // parameterless constructor required for deserialization by xunit
        public CodeSample()
        {

        }

        public CodeSample(string relativePath, int line, string code)
        {
            if (String.IsNullOrEmpty(relativePath))
                throw new ArgumentException("Value must not be empty", nameof(relativePath));

            RelativePath = relativePath;
            Line = line;
            SourceCode = code ?? throw new ArgumentNullException(nameof(code));
        }


        // line is zero based, convert to one-based line index for user-visible string
        public override string ToString() => $"{RelativePath}, line {Line + 1}";


        public void Deserialize(IXunitSerializationInfo info)
        {
            RelativePath = info.GetValue<string>(nameof(RelativePath));
            SourceCode = info.GetValue<string>(nameof(SourceCode));
            Line = info.GetValue<int>(nameof(Line));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(RelativePath), RelativePath);
            info.AddValue(nameof(SourceCode), SourceCode);
            info.AddValue(nameof(Line), Line);
        }
    }
}
