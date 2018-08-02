using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    public sealed class MdBlockQuote : MdContainerBlockBase
    {
        public MdBlockQuote(params MdBlock[] content) : base(content)
        { }

        public MdBlockQuote(IEnumerable<MdBlock> content) : base(content)
        { }

        public MdBlockQuote(MdSpan content) : this(new MdParagraph(content))
        { }

        public MdBlockQuote(params MdSpan[] content) : this(new MdParagraph(content))
        { }
    }
}
