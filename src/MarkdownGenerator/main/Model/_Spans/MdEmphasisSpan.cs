using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdEmphasisSpan : MdSpan
    {
        public string Text { get; }


        public MdEmphasisSpan(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
