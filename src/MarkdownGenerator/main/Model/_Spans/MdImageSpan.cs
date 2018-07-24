using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdImageSpan : MdSpan
    {
        public string Description { get; }

        public Uri Uri { get; }


        public MdImageSpan(string description, string uri) : this(description, new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        public MdImageSpan(string description, Uri uri)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }        
    }
}
