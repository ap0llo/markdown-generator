using System.Text;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Implementation of <see cref="ITextFormatter"/> optimized for rendering
    /// generated Markdown file using <see href="https://www.mkdocs.org/">MkDocs</see>.
    /// </summary>
    /// <remarks>
    /// This implementation works largely the same as <see cref="DefaultTextFormatter"/> but changes
    /// how some characters are escaped:
    /// <list type="bullet">
    ///     <item><description><c>&lt;</c> is escaped as <c>&amp;lt;</c>.</description></item>
    ///     <item><description><c>&gt;</c> is escaped as <c>&amp;gt;</c>.</description></item>
    /// </list>
    /// </remarks>
    public sealed class MkDocsTextFormatter : ITextFormatter
    {
        /// <summary>
        /// Gets the singleton instance of <see cref="MkDocsTextFormatter"/>
        /// </summary>
        public static readonly MkDocsTextFormatter Instance = new MkDocsTextFormatter();


        private MkDocsTextFormatter()
        { }


        /// <inheritdoc />
        public string EscapeText(string text)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '<':
                        stringBuilder.Append("&lt;");
                        break;
                    case '>':
                        stringBuilder.Append("&gt;");
                        break;

                    case '\\':
                    case '/':
                    case '*':
                    case '_':
                    case '-':
                    case '=':
                    case '#':
                    case '`':
                    case '~':
                    case '[':
                    case ']':
                    case '!':
                    case '|':
                        stringBuilder.Append('\\');
                        stringBuilder.Append(text[i]);
                        break;

                    default:
                        stringBuilder.Append(text[i]);
                        break;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
