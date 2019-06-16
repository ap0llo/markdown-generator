using System;
using Xunit;
using Xunit.Abstractions;
using Grynwald.MarkdownGenerator.Test.DocsVerification.Infrastructure;

namespace Grynwald.MarkdownGenerator.Test.DocsVerification
{
    /// <summary>
    /// Defines test methods that ensure all code samples in the
    /// documentation can be compiled
    /// </summary>
    [Trait("Category", "SkipWhenLiveUnitTesting")]
    public class CompilationTest
    {
        private readonly ITestOutputHelper m_OutputHelper;

        public CompilationTest(ITestOutputHelper outputHelper)
        {
            m_OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }


        [Theory(DisplayName ="Sample code is compile clean ")]
        [CodeSampleFromDocs(@"docs/examples")]
        [CodeSampleFromDocs(@"docs/api")]
        public void Sample_code_is_compile_clean(CodeSample codeSample)
        {
            CodeSampleAssert.NoCompilationErrors(codeSample);
        }
    }
}
