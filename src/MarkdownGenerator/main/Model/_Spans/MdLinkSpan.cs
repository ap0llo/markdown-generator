using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdLinkSpan : MdSpan
    {
        public MdSpan Text { get; }

        public Uri Uri { get; }


        public MdLinkSpan(string text, string uri) : this(new MdTextSpan(text), new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        public MdLinkSpan(string text, Uri uri) : this(new MdTextSpan(text), uri)
        { }

        public MdLinkSpan(MdSpan text, string uri) : this(text, new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        public MdLinkSpan(MdSpan text, Uri uri)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }        
    }
}
