using System;

namespace MarkdownBuilder.Model
{
    public class MdParagraph : MdBlock
    {                
        public string Text { get; }


        public MdParagraph(string text) =>
            //TODO: handle blank lines within paragraph  
            Text = text ?? throw new ArgumentNullException(nameof(text));
    }
}
