using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal static class StringBuilderExtensions
    {
        public static void AppendRepeat(this StringBuilder stringBuilder, char c, int count)
        {
            for (var i = 0; i < count; i++)
            {
                stringBuilder.Append(c);
            }
        }
    }
}
