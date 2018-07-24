using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdStrongEmphasisSpan : MdSpan
    {
        public string Text { get; }


        public MdStrongEmphasisSpan(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
