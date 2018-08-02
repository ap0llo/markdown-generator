using System.IO;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// A block in a markdown document. 
    /// Blocks are the basic buidling units of markdown documents. 
    /// A document consists of one or more blocks.
    /// </summary>
    public abstract class MdBlock
    {

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdBlock()
        {
        }

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
