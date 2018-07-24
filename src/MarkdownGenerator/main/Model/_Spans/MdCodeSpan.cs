using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdCodeSpan : MdSpan
    {
        public string Text { get; }


        public MdCodeSpan(string text) => 
            Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
