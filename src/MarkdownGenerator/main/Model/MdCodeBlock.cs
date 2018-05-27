using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdCodeBlock : MdLeafBlock
    {
        public string Text { get; }

        public string InfoString { get; }


        public MdCodeBlock(string text, string infoString = null)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            InfoString = infoString;
        }
    }
}
