using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a item in an bullet or ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdListItem : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new, empty instance of <see cref="MdListItem"/>.
        /// </summary>
        public MdListItem() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The block to initially add to the list item.</param>
        public MdListItem(MdContainerBlockBase content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The list to initially add to the list item.</param>
        public MdListItem(MdList content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public MdListItem(params MdBlock[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public MdListItem(IEnumerable<MdBlock> content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified span
        /// </summary>
        /// <param name="content">
        /// The list item's content as a <see cref="MdSpan"/>.
        /// The span will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public MdListItem(MdSpan content) : this(new MdParagraph(content))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified spans
        /// </summary>
        /// <param name="content">
        /// The list item's content as one or more instances of <see cref="MdSpan"/>.
        /// The spans will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public MdListItem(params MdSpan[] content) : this(new MdParagraph(content))
        { }


        public override bool DeepEquals(MdBlock other) => other is MdListItem listItem ? DeepEquals(listItem) : false;
    }
}
