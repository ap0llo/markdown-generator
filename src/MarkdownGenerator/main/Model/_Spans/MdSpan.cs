using System.IO;
using Grynwald.MarkdownGenerator.Utilities;

namespace Grynwald.MarkdownGenerator.Model
{
    public abstract class MdSpan
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdSpan()
        {
        }

        public override string ToString()
        {
            using (var stringWriter = new StringWriter())
            {
                var documentSerializer = new SpanSerializer(stringWriter);
                documentSerializer.Serialize(this);
                return stringWriter.ToString();
            }
        }
    }
}
