using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Grynwald.MarkdownGenerator.Extensions;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    // TODO: Consider removing Root property and deriving from MdContainerBlock instead
    /// <summary>
    /// Represents a markdown document
    /// </summary>
    public sealed class MdDocument : IDocument
    {
        /// <summary>
        /// The root container block containing all of the document's blocks
        /// </summary>
        public MdContainerBlock Root { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified block as root element.
        /// </summary>
        /// <param name="root">The documents root block</param>
        public MdDocument(MdContainerBlock root) =>
            Root = root ?? throw new ArgumentNullException(nameof(root));

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public MdDocument(params MdBlock[] content) : this(new MdContainerBlock(content))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public MdDocument(IEnumerable<MdBlock> content) : this(new MdContainerBlock(content))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdList implements <see cref="IEnumerable{MdListItem}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public MdDocument(MdList list) : this((MdBlock)list)
        { }


        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdBlockQuote implements <see cref="IEnumerable{MdListItem}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public MdDocument(MdBlockQuote list) : this((MdBlock)list)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdAdmonition implements <see cref="IEnumerable{MdBlock}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public MdDocument(MdAdmonition admonition) : this((MdBlock)admonition)
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
        public void Save(string path, MdSerializationOptions? serializationOptions)
        {
            using (var stream = File.Open(path, FileMode.Create))
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
        /// <param name="serializationOptions">The options to use for converting the document to Markdown.</param>
        public void Save(Stream stream, MdSerializationOptions? serializationOptions)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                Save(writer, serializationOptions);
            }
        }

        private void Save(TextWriter writer, MdSerializationOptions? serializationOptions)
        {
            var serializer = new DocumentSerializer(writer, serializationOptions);
            serializer.Serialize(this);
        }

        /// <summary>
        /// Converts the document to a Markdown string.
        /// </summary>
        /// <returns>Returns the Markdown representation of the document.</returns>
        public override string ToString() => ToString(null);

        /// <summary>
        /// Converts the document to a Markdown string using the specified serialization options.
        /// </summary>
        /// <param name="serializationOptions">The options to use for converting the document to Markdown.</param>
        /// <returns>Returns the Markdown representation of the document.</returns>
        public string ToString(MdSerializationOptions? serializationOptions)
        {
            using (var stringWriter = new StringWriter())
            {
                Save(stringWriter, serializationOptions);
                return stringWriter.ToString();
            }
        }
    }
}
