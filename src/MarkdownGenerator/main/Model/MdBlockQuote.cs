using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdBlockQuote : MdContainerBlockBase
    {
        public MdBlockQuote(params MdBlock[] content) : base(content)
        { }

        public MdBlockQuote(IEnumerable<MdBlock> content) : base(content)
        { }

        public MdBlockQuote(string content) : this(new MdParagraph(content))
        { }
    }
}
