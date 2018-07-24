using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a item in an (unordered) list
    /// </summary>
    public sealed class MdListItem : MdContainerBlockBase
    {
        public MdListItem(params MdBlock[] items) : base(items)
        { }

        public MdListItem(IEnumerable<MdBlock> items) : base(items)
        { }

        public MdListItem(params MdSpan[] content) : this(new MdParagraph(content))
        { }

        public MdListItem(string content) : this(new MdParagraph(content))
        { }
    }
}
