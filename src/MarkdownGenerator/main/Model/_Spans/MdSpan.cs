using System.IO;
using Grynwald.MarkdownGenerator.Utilities;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represent a inline text element in a markdown document
    /// </summary>
    public abstract class MdSpan
    {
        private readonly SpanSerializer m_SpanSerializer = new SpanSerializer();


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdSpan()
        {
        }


        public override string ToString() =>
            m_SpanSerializer.ConvertToString(this);
    }
}
