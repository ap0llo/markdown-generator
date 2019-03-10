using System.IO;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a block in a markdown document.
    /// Blocks are the basic building units of markdown documents.
    /// A document consists of one or more blocks.
    /// </summary>
    public abstract class MdBlock
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdBlock()
        { }


        public override string ToString() => ToString(MdSerializationOptions.Default);

        public virtual string ToString(MdSerializationOptions options)
        {
            using (var stringWriter = new StringWriter())
            {
                var documentSerializer = new DocumentSerializer(stringWriter, options);
                documentSerializer.Serialize(this);
                return stringWriter.ToString();
            }
        }

        public abstract bool DeepEquals(MdBlock other);
    }
}
