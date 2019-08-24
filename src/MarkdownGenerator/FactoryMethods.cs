using System;
using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Extensions;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines static factory methods for blocks in markdown documents.
    /// When imported via "using static", this allows for more readable 
    /// construction of documents, e.g.
    /// <code>
    ///   new MdDocument(new MdParagraph("My content")) 
    /// </code>
    /// can be rewritten as
    /// <code>
    ///   Document(Paragraph("My Content"))
    /// </code>
    /// </summary>
    public static partial class FactoryMethods
    {
        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified block as root element.
        /// </summary>
        /// <param name="root">The documents root block</param>
        public static MdDocument Document(MdContainerBlock root) => new MdDocument(root);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public static MdDocument Document(params MdBlock[] content) => new MdDocument(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public static MdDocument Document(IEnumerable<MdBlock> content) => new MdDocument(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdList implements <see cref="IEnumerable{MdListItem}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public static MdDocument Document(MdList list) => new MdDocument(list);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdBlockQuote implements <see cref="IEnumerable{MdBlock}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public static MdDocument Document(MdBlockQuote blockQuote) => new MdDocument(blockQuote);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdAdmonition implements <see cref="IEnumerable{MdBlock}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public static MdDocument Document(MdAdmonition admonition) => new MdDocument(admonition);


        /// <summary>
        /// Creates a new instance if <see cref="MdDocumentSet"/>.
        /// </summary>
        [Obsolete("MdDocumentSet is obsolete, use DocumentSet<MdDocument> instead.")]
        public static MdDocumentSet DocumentSet() => new MdDocumentSet();
    }
}
