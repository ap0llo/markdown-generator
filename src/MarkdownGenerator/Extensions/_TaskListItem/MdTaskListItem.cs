using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator.Extensions
{
    /// <summary>
    /// Represents a "task list item" as defined by GitHub Flavored Markdown
    /// </summary>
    /// <remarks>
    /// Using this element will produce markdown which might not be rendered correctly
    /// by all Markdown implementation and should only be used, when the renderer
    /// is known to support GitHub Flavored Markdown.
    /// </remarks>
    /// <seealso href="https://github.github.com/gfm/#task-list-items-extension-">GitHub Flavored Markdown Spec - Task list items</seealso>
    public sealed class MdTaskListItem : MdListItemBase
    {
        /// <inheritdoc />
        internal override string AdditionalListItemMarker => IsChecked ? "[x] " : "[ ] ";


        /// <summary>
        /// Gets or sets whether the task list item is checked
        /// </summary>
        public bool IsChecked { get; set; } = false;


        /// <summary>
        /// Initializes a new, empty instance of <see cref="MdTaskListItem"/>.
        /// </summary>
        public MdTaskListItem() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The block to initially add to the list item.</param>
        public MdTaskListItem(MdContainerBlockBase content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The list to initially add to the list item.</param>
        public MdTaskListItem(MdList content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public MdTaskListItem(params MdBlock[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public MdTaskListItem(IEnumerable<MdBlock> content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified span.
        /// </summary>
        /// <param name="content">
        /// The list item's content as a <see cref="MdSpan"/>.
        /// The span will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public MdTaskListItem(MdSpan content) : this(new MdParagraph(content))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTaskListItem"/> containing the specified spans.
        /// </summary>
        /// <param name="content">
        /// The list item's content as one or more instances of <see cref="MdSpan"/>.
        /// The spans will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public MdTaskListItem(params MdSpan[] content) : this(new MdParagraph(content))
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => other is MdTaskListItem listItem ? DeepEquals(listItem) : false;


        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
