using System;
using System.IO;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a block in a Markdown document.
    /// <remarks>
    /// Blocks are the basic building units of Markdown documents, every 
    /// document consists of one or more blocks.
    /// </remarks>
    /// </summary>
    public abstract class MdBlock
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdBlock()
        { }

        /// <summary>
        /// Converts the block to a string using the default serialization options.
        /// </summary>
        /// <returns>Returns the Markdown text corresponding to the block.</returns>
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <summary>
        /// Converts the block to a string using the specified serialization options.
        /// </summary>
        /// <param name="options">The serialization options to use.</param>
        /// <returns>Returns the Markdown text corresponding to the block.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is <c>null</c>.</exception>
        public virtual string ToString(MdSerializationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            using (var stringWriter = new StringWriter())
            {
                var documentSerializer = new DocumentSerializer(stringWriter, options);
                Accept(documentSerializer);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Recursively compares the block to the specified block.
        /// </summary>
        /// <param name="other">The block to compare to.</param>
        /// <returns>
        /// Returns <c>true</c> if both blocks are semantically equivalent,
        /// i.e. serializing them with the same serialization options would
        /// result in the same Markdown output.
        /// Otherwise returns <c>false</c>.
        /// </returns>
        public abstract bool DeepEquals(MdBlock other);


        internal abstract void Accept(IBlockVisitor visitor);
    }
}
