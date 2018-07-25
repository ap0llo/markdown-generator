using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    /// <summary>
    /// Data attribute that supplies characters that need to be escaped in a
    /// markdown document to test methods
    /// </summary>
    public class MarkdownSpecialCharacterDataAttribute : DataAttribute
    {
        private readonly char[] m_Chars = @"<>/\*_-=#`~[]!|".ToCharArray();
        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod) => 
            m_Chars.Select(c => new object[] { c });
    }
}
