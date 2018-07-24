using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdTextSpan : MdSpan
    {
        public string Text { get; }


        public MdTextSpan(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
