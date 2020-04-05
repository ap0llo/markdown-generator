using System.Text;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Default implementation of <see cref="ITextFormatter"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="DefaultTextFormatter"/> escapes all characters with a function in the Markdown syntax
    /// using a backslash.
    /// </remarks>
    public sealed class DefaultTextFormatter : ITextFormatter
    {
        /// <summary>
        /// Gets the singleton instance of <see cref="DefaultTextFormatter"/>
        /// </summary>
        public static readonly DefaultTextFormatter Instance = new DefaultTextFormatter();


        private DefaultTextFormatter()
        { }


        /// <inheritdoc />
        public string EscapeText(string text)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '\\':
                    case '/':
                    case '<':
                    case '>':
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
                        break;

                    default:
                        break;
                }
                stringBuilder.Append(text[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
