using System;
using System.IO;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a plain text document.
    /// </summary>
    /// <remarks>
    /// Implementation of <see cref="IDocument"/> for plain text that allows adding non-markdown documents to a <see cref="DocumentSet{T}"/>.
    /// </remarks>
    public class TextDocument : IDocument
    {
        /// <summary>
        /// Gets or sets the content of the text document.
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// Initializes a new empty <see cref="TextDocument"/>.
        /// </summary>
        public TextDocument() : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="TextDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">The text document's content.</param>
        public TextDocument(string content)
        {
            Content = content;
        }


        /// <inheritdoc />
        public void Save(string path) => File.WriteAllText(path, Content ?? "");
    }
}
