using System;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{

    public static partial class FactoryMethods
    {

        public static MdLinkSpan Link(string text, string uri) => new MdLinkSpan(text, uri);

        public static MdLinkSpan Link(string text, Uri uri) => new MdLinkSpan(text, uri);

        public static MdLinkSpan Link(MdSpan text, string uri) => new MdLinkSpan(text, uri);

        public static MdLinkSpan Link(MdSpan text, Uri uri) => new MdLinkSpan(text, uri);


        public static MdImageSpan Image(string description, string uri) => new MdImageSpan(description, uri);

        public static MdImageSpan Image(string description, Uri uri) => new MdImageSpan(description, uri);

        public static MdImageSpan Image(MdSpan description, string uri) => new MdImageSpan(description, uri);

        public static MdImageSpan Image(MdSpan description, Uri uri) => new MdImageSpan(description, uri);


        public static MdEmphasisSpan Emphasis(string text) => new MdEmphasisSpan(text);

        public static MdEmphasisSpan Emphasis(MdSpan text) => new MdEmphasisSpan(text);

        public static MdEmphasisSpan Italic(string text) => Emphasis(text);

        public static MdEmphasisSpan Italic(MdSpan text) => Emphasis(text);


        public static MdStrongEmphasisSpan StrongEmphasis(string text) => new MdStrongEmphasisSpan(text);

        public static MdStrongEmphasisSpan StrongEmphasis(MdSpan text) => new MdStrongEmphasisSpan(text);

        public static MdStrongEmphasisSpan Bold(string text) => StrongEmphasis(text);

        public static MdStrongEmphasisSpan Bold(MdSpan text) => StrongEmphasis(text);


        public static MdCodeSpan CodeSpan(string text) => new MdCodeSpan(text);


        public static MdCompositeSpan CompositeSpan(params MdSpan[] spans) => new MdCompositeSpan(spans);

        public static MdCompositeSpan CompositeSpan(IEnumerable<MdSpan> spans) => new MdCompositeSpan(spans);


        public static MdRawMarkdownSpan RawMarkdown(string content) => new MdRawMarkdownSpan(content);


        public static MdTextSpan Text(string text) => new MdTextSpan(text);
    }
}
