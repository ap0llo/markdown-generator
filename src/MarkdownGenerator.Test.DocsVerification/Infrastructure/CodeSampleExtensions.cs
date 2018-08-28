using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure
{
    internal static class CodeSampleExtensions
    {
        public static Compilation GetCompilation(this CodeSample codeSample)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(codeSample.SourceCode);

            var assemblyName = "Compilation_" + Path.GetRandomFileName();

            return CSharpCompilation.Create(
              assemblyName,
              new[] { syntaxTree },
              GetMetadataReferences(),
              new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }


        private static MetadataReference[] GetMetadataReferences()
        {
            return new MetadataReference[]
            {
                MetadataReference.CreateFromFile(Assembly.Load("netstandard").Location),
                MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(MdDocument).Assembly.Location)
            };
        }
    }
}
