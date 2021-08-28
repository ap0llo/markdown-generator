using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for list item implementations
    /// </summary>
    public abstract class MdListItemBase : MdContainerBlockBase
    {
        /// <summary>
        /// Gets a custom list marker to add after the list's primary list marker when serializing this list item to Markdown.
        /// Empty by default.
        /// </summary>
        internal virtual string AdditionalListItemMarker { get; } = "";


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase() : base()
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(MdContainerBlockBase content) : base(content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(MdList content) : base(content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(params MdBlock[] content) : base(content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(IEnumerable<MdBlock> content) : base(content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(MdSpan content) : this(new MdParagraph(content))
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdListItemBase(params MdSpan[] content) : this(new MdParagraph(content))
        { }
    }
}
