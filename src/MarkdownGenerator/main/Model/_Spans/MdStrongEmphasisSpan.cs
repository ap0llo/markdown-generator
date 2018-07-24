using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdStrongEmphasisSpan : MdSpan
    {
        public MdSpan Text { get; }


        public MdStrongEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        public MdStrongEmphasisSpan(MdSpan text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
