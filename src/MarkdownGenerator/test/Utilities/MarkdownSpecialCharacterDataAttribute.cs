using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    public class MarkdownSpecialCharacterDataAttribute : DataAttribute
    {
        private readonly char[] m_Chars = @"<>/\*_-=#`~[]!".ToCharArray();
        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod) => 
            m_Chars.Select(c => new object[] { c });
    }
}
