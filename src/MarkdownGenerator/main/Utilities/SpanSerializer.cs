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
        
        
        public SpanSerializer()
        {
        }


        public string ConvertToString(MdSpan span)
        {
            using (var stringWriter = new StringWriter())
            {                
                WriteTo(span, stringWriter, false);
                return stringWriter.ToString();
            }
        }
        

        private void WriteTo(MdSpan span, TextWriter writer, bool removeLineBreaks)
        {
            switch (span)
            {
                case MdCompositeSpan compositeSpan:
                    WriteTo(compositeSpan, writer, removeLineBreaks);
                    break;

                case MdRawTextSpan rawTextSpan:
                    WriteTo(rawTextSpan, writer, removeLineBreaks);
                    break;

                case MdLinkSpan linkSpan:
                    WriteTo(linkSpan, writer, removeLineBreaks);
                    break;

                case MdImageSpan imageSpan:
                    WriteTo(imageSpan, writer, removeLineBreaks);
                    break;

                case MdEmphasisSpan emphasisSpan:
                    WriteTo(emphasisSpan, writer, removeLineBreaks);
                    break;

                case MdStrongEmphasisSpan strongEmphasisSpan:
                    WriteTo(strongEmphasisSpan, writer, removeLineBreaks);
                    break;

                case MdTextSpan textSpan:
                    WriteTo(textSpan, writer, removeLineBreaks);
                    break;

                case MdCodeSpan codeSpan:
                    WriteTo(codeSpan, writer, removeLineBreaks);
                    break;

                case MdSingleLineSpan singleLineSpan:
                    WriteTo(singleLineSpan, writer, removeLineBreaks);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported span type {span.GetType().FullName}");
            }
        }        

        private void WriteTo(MdCompositeSpan compositeSpan, TextWriter writer, bool removeLineBreaks)
        {
            foreach (var span in compositeSpan)
            {
                WriteTo(span, writer, removeLineBreaks);
            }
        }

        private void WriteTo(MdRawTextSpan span, TextWriter writer, bool removeLineBreaks) => writer.Write(span.RawMarkdown);

        private void WriteTo(MdLinkSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write("[");
            WriteTo(span.Text, writer, removeLineBreaks);
            writer.Write("]");
            writer.Write("(");
            writer.Write(span.Uri);
            writer.Write(")");
        }
        
        private void WriteTo(MdImageSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write("![");
            WriteTo(span.Description, writer, removeLineBreaks);
            writer.Write("]");
            writer.Write("(");
            writer.Write(span.Uri);
            writer.Write(")");            
        }
        
        private void WriteTo(MdEmphasisSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write("*");
            WriteTo(span.Text, writer, removeLineBreaks);
            writer.Write("*");            
        }

        private void WriteTo(MdStrongEmphasisSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write("**");
            WriteTo(span.Text, writer, removeLineBreaks);
            writer.Write("**");
        }

        private void WriteTo(MdTextSpan span, TextWriter writer, bool removeLineBreaks)
        {
            var text = span.Text;

            if(removeLineBreaks)
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
                        writer.Write('\\');
                        break;

                    default:
                        break;
                }
                writer.Write(text[i]);
            }
        }

        private void WriteTo(MdCodeSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write("`");
            writer.Write(span.Text);
            writer.Write("`");            
        }

        private void WriteTo(MdSingleLineSpan singleLineSpan, TextWriter writer, bool removeLineBreaks)
        {
            WriteTo(singleLineSpan.Content, writer, true);
        }

    }
}
