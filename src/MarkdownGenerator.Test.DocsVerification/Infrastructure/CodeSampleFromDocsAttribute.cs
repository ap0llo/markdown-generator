using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Markdig;
using Markdig.Syntax;
using Xunit.Sdk;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{    
    /// <summary>
    /// Test data attribute that supplies instances of <see cref="CodeSample"/> to test methods.
    /// The code samples are read from documentation markdown documents.
    /// The relative path passed to the constructor specifies the directory to read files from
    /// </summary>
    public class CodeSampleFromDocsAttribute : DataAttribute
    {        
        private readonly string m_RelativeSourcePath;


        public CodeSampleFromDocsAttribute(string relativeSourcePath)
        {
            if (string.IsNullOrEmpty(relativeSourcePath))
                throw new ArgumentException("Value must not be empty", nameof(relativeSourcePath));

            m_RelativeSourcePath = relativeSourcePath;
        }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // docs are copied to the output directory by a build task
            // so all relative paths, are relative to <Working Direcotry>\content
            var dirPath = Path.Combine("content", m_RelativeSourcePath);

            // iterate over all files and read the code samples from the markdown file
            foreach(var filePath in Directory.GetFiles(dirPath, "*.md"))
            {
                var relativeFilePath = Path.Combine(m_RelativeSourcePath, Path.GetFileName(filePath));

                var text = File.ReadAllText(filePath);
                var markdownDocument = Markdown.Parse(text);

                var codeBlocks = markdownDocument.OfType<FencedCodeBlock>()
                    .Where(IsCSharpCodeBlock)
                    .ToArray();
                
                foreach (var codeBlock in codeBlocks)
                {                   
                    var codeSample = new CodeSample(
                        relativeFilePath,
                        // code sample starts in the second line of the fenced code block (first line is fence and info string)
                        codeBlock.Line + 1, 
                        codeBlock.Lines.ToString());

                    yield return new[] { codeSample };
                }
            }
        }

        private static bool IsCSharpCodeBlock(FencedCodeBlock codeBlock)
        {
            return codeBlock.Info
                .Split()
                .Any(x => x.Equals("csharp", StringComparison.OrdinalIgnoreCase));
        }
    }
}
