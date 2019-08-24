using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Provides Markdown-specific extension methods for <see cref="DocumentSet{T}"/>.
    /// </summary>
    public static class DocumentSetExtensions
    {
        /// <summary>
        /// Creates a new <see cref="MdDocument"/> and adds it to the document set.
        /// </summary>
        /// <param name="documentSet">The document set to create the document set in.</param>
        /// <param name="path">The path of the document to create.</param>
        /// <returns>Returns the created document.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is null of empty.</exception>
        /// <exception cref="ArgumentException">Thrown when the document set already contains a document with the specified path.</exception>
        public static MdDocument CreateDocument(this DocumentSet<MdDocument> documentSet, string path)
        {
            var document = new MdDocument();
            documentSet.Add(path, document);
            return document;
        }

        /// <summary>
        /// Creates a markdown link element (see <see cref="MdLinkSpan"/>) with a relative link between the specified documents.
        /// </summary>
        /// <param name="documentSet">The <see cref="DocumentSet{T}"/> to get the relative path from.</param>
        /// <param name="from">The link source (i.e. the document the link span will be placed in).</param>
        /// <param name="to">The links's target.</param>
        /// <param name="linkText">The link text</param>
        /// <returns>Returns a new <see cref="MdLinkSpan"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="linkText"/> is null.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when <paramref name="from"/> is not part of the document set.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when <paramref name="to"/> is not part of the document set.</exception>
        public static MdLinkSpan GetLink<T>(this DocumentSet<T> documentSet, T from, T to, MdSpan linkText) where T : IDocument
        {
            if (linkText == null)
                throw new ArgumentNullException(nameof(linkText));

            var relativePath = documentSet.GetRelativePath(from, to);

            return new MdLinkSpan(linkText, relativePath);
        }

        /// <summary>
        /// Saves all the set's documents to the specified output directory using the specified serialization options.
        /// </summary>
        /// <param name="documentSet">The document set to save.</param>
        /// <param name="directoryPath">The directory path to save the documents to.</param>
        /// <param name="cleanOutputDirectory">Determines whether the output directory is deleted before saving the documents.</param>
        /// <param name="serializationOptions">The serialization options to use for saving the documents. Can be <c>null</c>.</param>
        public static void Save(this DocumentSet<MdDocument> documentSet, string directoryPath, bool cleanOutputDirectory, MdSerializationOptions serializationOptions)
        {
            documentSet.Save(directoryPath, cleanOutputDirectory, (document, path) => document.Save(path, serializationOptions));
        }
    }
}
