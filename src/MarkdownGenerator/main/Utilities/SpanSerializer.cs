using System;
using System.IO;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class SpanSerializer
    {

        private readonly TextWriter m_Writer;

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

        //TODO: Escape link text
        private void Serialize(MdLinkSpan span) => m_Writer.Write($"[{span.Text}]({span.Uri})");

        //TODO: Escape image description
        private void Serialize(MdImageSpan span) => m_Writer.Write($"![{span.Description}]({span.Uri})");

        //TODO: Escape emphasized content
        private void Serialize(MdEmphasisSpan span) => m_Writer.Write($"*{span.Text}*");

        //TODO: Escape emphasized content
        private void Serialize(MdStrongEmphasisSpan span) => m_Writer.Write($"**{span.Text}**");

    }
}
