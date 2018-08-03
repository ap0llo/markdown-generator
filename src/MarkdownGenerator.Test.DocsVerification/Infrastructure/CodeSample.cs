using System;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    public class CodeSample
    {
        public string Name { get; }

        public string Code { get; }


        public CodeSample(string name, string code)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Value must not be empty", nameof(name));

            Name = name;
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }


        public override string ToString() => Name;    
    }
}
