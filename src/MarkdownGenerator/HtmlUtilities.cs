using System;
using System.Text;

namespace Grynwald.MarkdownGenerator
{
    public static class HtmlUtilities
    {
        /// <summary>
        /// Generates a "url slug" from the specified value that can be used as a HTML id in a Markdown document.
        /// </summary>
        /// <remarks>
        /// This method can be used to generate a id for linking within a document (typically a link to a heading).
        /// <para>
        /// There is no official spec for how anchors for headings work. This implementation follows the guidance from <see href="https://stackoverflow.com/questions/27981247/github-markdown-same-page-link">Stack Overflow</see>:
        /// <list type="bullet">
        ///     <item><description>Leading and trailing whitespace is dropped.</description></item>
        ///     <item><description>Punctuation marks are dropped.</description></item>
        ///     <item><description>Upper case letters are converted to lower case.</description></item>
        ///     <item><description>Spaces are replaced with <c>-</c></description></item>
        /// </list>
        /// </para>
        /// </remarks>
        public static string ToUrlSlug(string? value)
        {
            value = value?.Trim();

            if (String.IsNullOrEmpty(value))
            {
                return "";
            }

            var anchor = new StringBuilder();

            foreach (var c in value!)
            {
                if (Char.IsLetter(c) || Char.IsNumber(c))
                {
                    anchor.Append(Char.ToLower(c));
                }
                else if (Char.IsWhiteSpace(c))
                {
                    anchor.Append('-');
                }
            }

            return anchor.ToString();
        }

    }
}
