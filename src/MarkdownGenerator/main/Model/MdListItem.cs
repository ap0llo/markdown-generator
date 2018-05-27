﻿using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a item in an (unordered) list
    /// </summary>
    public sealed class MdListItem : MdContainerBlock
    {
        public MdListItem(params MdBlock[] items) : base(items)
        { }

        public MdListItem(IEnumerable<MdBlock> items) : base(items)
        { }

        public MdListItem(string content) : this(new MdParagraph(content))
        { }
    }
}
