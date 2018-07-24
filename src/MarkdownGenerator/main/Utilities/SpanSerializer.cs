using System;
using System.IO;
using System.Text.RegularExpressions;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class SpanSerializer
    {
        private static readonly Regex s_LineBreakPattern = new Regex(@"(\s)*[\r\n]+(\s)*", RegexOptions.Compiled);
        private static readonly Regex s_TrailingLineBreakRegex = new Regex(@"[\r\n]+$", RegexOptions.Compiled);

        private readonly TextWriter m_Writer;
        private int m_RemoveLineBreaks = 0;

        public SpanSerializer(TextWriter writer)
        {
            m_Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }


        public void Serialize(MdSpan span)
        {
            switch (span)
            {
                case MdCompositeSpan compositeSpan:
                    Serialize(compositeSpan);
                    break;

                case MdRawTextSpan rawTextSpan:
                    Serialize(rawTextSpan);
                    break;

                case MdLinkSpan linkSpan:
                    Serialize(linkSpan);
                    break;

                case MdImageSpan imageSpan:
                    Serialize(imageSpan);
                    break;

                case MdEmphasisSpan emphasisSpan:
                    Serialize(emphasisSpan);
                    break;

                case MdStrongEmphasisSpan strongEmphasisSpan:
                    Serialize(strongEmphasisSpan);
                    break;

                case MdTextSpan textSpan:
                    Serialize(textSpan);
                    break;

                case MdCodeSpan codeSpan:
                    Serialize(codeSpan);
                    break;

                case MdSingleLineSpan singleLineSpan:
                    Serialize(singleLineSpan);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported span type {span.GetType().FullName}");
            }
        }


        private void Serialize(MdCompositeSpan compositeSpan)
        {
            foreach (var span in compositeSpan)
            {
                Serialize(span);
            }
        }

        private void Serialize(MdRawTextSpan span) => m_Writer.Write(span.RawMarkdown);

        private void Serialize(MdLinkSpan span)
        {
            m_Writer.Write("[");
            Serialize(span.Text);
            m_Writer.Write("]");
            m_Writer.Write("(");
            m_Writer.Write(span.Uri);
            m_Writer.Write(")");
        }
        
        private void Serialize(MdImageSpan span)
        {
            m_Writer.Write("![");
            Serialize(span.Description);
            m_Writer.Write("]");
            m_Writer.Write("(");
            m_Writer.Write(span.Uri);
            m_Writer.Write(")");            
        }
        
        private void Serialize(MdEmphasisSpan span)
        {
            m_Writer.Write("*");
            Serialize(span.Text);
            m_Writer.Write("*");            
        }

        private void Serialize(MdStrongEmphasisSpan span)
        {
            m_Writer.Write("**");
            Serialize(span.Text);
            m_Writer.Write("**");
        }

        private void Serialize(MdTextSpan span)
        {
            var text = span.Text;

            if(m_RemoveLineBreaks > 0)
            {
                // remove trailing line breaks
                text = s_TrailingLineBreakRegex.Replace(text, "");

                // replace other line breaks with spaces. 
                // If linebreaks are folowed/precedded by whitespace
                // replace whitespace and line break with a single
                // space
                text = s_LineBreakPattern.Replace(text, " ");
            }

            
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
                        m_Writer.Write('\\');
                        break;

                    default:
                        break;
                }
                m_Writer.Write(text[i]);
            }
        }

        private void Serialize(MdCodeSpan span)
        {
            m_Writer.Write("`");
            m_Writer.Write(span.Text);
            m_Writer.Write("`");            
        }

        private void Serialize(MdSingleLineSpan singleLineSpan)
        {
            m_RemoveLineBreaks += 1;
            Serialize(singleLineSpan.Content);
            m_RemoveLineBreaks -= 1;
        }

    }
}
