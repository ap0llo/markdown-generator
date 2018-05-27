using Grynwald.MarkdownGenerator.Utilities;
using System.IO;

namespace Grynwald.MarkdownGenerator.Model
{
    public abstract class MdBlock
    {
        public override string ToString()
        {
            using (var stringWriter = new StringWriter())
            {
                var documentSerializer = new DocumentSerializer(stringWriter);
                documentSerializer.Serialize(this);
                return stringWriter.ToString();
            }
        }
    }
}
