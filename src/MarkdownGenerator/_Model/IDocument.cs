namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an arbitrary document.
    /// </summary>
    /// <seealso cref="MdDocument"/>
    /// <seealso cref="DocumentSet{T}"/>
    public interface IDocument
    {
        /// <summary>
        /// Writes the document's content to the specified file.
        /// </summary>
        /// <param name="path">The path of the file to save the document to.</param>
        void Save(string path);
    }
}
