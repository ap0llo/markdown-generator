using System;
using System.IO;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class TextSpanSerializer
    {

        private readonly TextWriter m_Writer;

        public TextSpanSerializer(TextWriter writer)
        {
            m_Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }


        public void Serialize(MdTextSpan span)
        {
            switch (span)
            {
                case MdCompositeTextSpan compositeSpan:
                    Serialize(compositeSpan);
                    break;

                case MdRawTextSpan rawTextSpan:
                    Serialize(rawTextSpan);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported span type {span.GetType().FullName}");
            }
        }


        private void Serialize(MdRawTextSpan span) => m_Writer.Write(span.RawMarkdown);

        private void Serialize(MdCompositeTextSpan compositeSpan)
        {
            foreach(var span in compositeSpan)
            {
                Serialize(span);
            }
        }
    }
}
