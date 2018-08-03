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
        private readonly string m_RelativePath;


        public CodeSampleFromDocsAttribute(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                throw new ArgumentException("message", nameof(relativePath));

            m_RelativePath = relativePath;
        }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // docs are copied to the output directory by a build task
            // so all relative paths, are relative to <Working Direcotry>\content
            var dirPath = Path.Combine("content", m_RelativePath);

            // iterate over all files and read the code samples from the markdown file
            foreach(var filePath in Directory.GetFiles(dirPath, "*.md"))
            foreach (var codeSample in GetCodeSamplesFromMarkdownFile(filePath))
            {
                {
                    yield return new[] { codeSample };
                }
            }
        }


        private IEnumerable<CodeSample> GetCodeSamplesFromMarkdownFile(string path)
        {
            var text = File.ReadAllText(path);
            var markdownDocument = Markdown.Parse(text);
            
            var codeBlocks = markdownDocument.OfType<FencedCodeBlock>()
                .Where(codeBlock => codeBlock.Info.Split().Any(x => x.Equals("csharp", StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            var fileName = Path.GetFileName(path);

            foreach (var codeBlock in codeBlocks)
            {
                yield return new CodeSample(
                    $"{Path.Combine(m_RelativePath, fileName)}, line {codeBlock.Line + 1}", 
                    codeBlock.Lines.ToString()
                );                
            }
        }
    }
}
