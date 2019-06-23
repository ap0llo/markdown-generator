using System.IO;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a markdown document
    /// </summary>
    public sealed class MdDocument : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified block as root element.
        /// </summary>
        public MdDocument() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public MdDocument(params object[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public MdDocument(object content) : base(content)
        { }

        /// <summary>
        /// Saves the document to the specified file.
        /// </summary>
        /// <param name="path">The path of the file to save the document to.</param>
        public void Save(string path) => Save(path, null);

        /// <summary>
        /// Saves the document to the specified file using the specified serialization options.
        /// </summary>
        /// <param name="path">The path of the file to save the document to.</param>
        /// <param name="serializationOptions">The options to use for serialization.</param>
        public void Save(string path, MdSerializationOptions serializationOptions)
        {
            using(var stream = File.Open(path, FileMode.Create))
            {
                Save(stream, serializationOptions);
            }
        }

        /// <summary>
        /// Saves the document to a stream.
        /// </summary>
        /// <param name="stream">The stream to write the document to.</param>
        public void Save(Stream stream) => Save(stream, null);

        /// <summary>
        /// Saves the document to a stream using the specified serialization options.
        /// </summary>
        /// <param name="stream">The stream to write the document to.</param>
        /// <param name="serializationOptions">The options to use for serialization.</param>
        public void Save(Stream stream, MdSerializationOptions serializationOptions)
        {
            using (var writer = new StreamWriter(stream, Encoding.Default, 1024, true))
            {
                Save(writer, serializationOptions);
            }
        }

        private void Save(TextWriter writer, MdSerializationOptions serializationOptions)
        {
            var serializer = new DocumentSerializer(writer, serializationOptions);
            serializer.Serialize(this);
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdDocument containerBlock ? DeepEquals(containerBlock) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
