using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdLinkSpan : MdSpan
    {
        public string Text { get; }

        public Uri Uri { get; }


        public MdLinkSpan(string text, string uri) : this(text, new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        public MdLinkSpan(string text, Uri uri)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }        
    }
}
