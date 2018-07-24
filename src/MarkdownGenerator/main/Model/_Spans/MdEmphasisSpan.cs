using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdEmphasisSpan : MdSpan
    {
        public MdSpan Text { get; }


        public MdEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        public MdEmphasisSpan(MdSpan text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
