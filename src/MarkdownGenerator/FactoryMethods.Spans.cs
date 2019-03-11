using System;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    public static partial class FactoryMethods
    {
        /// <summary>
        /// Creates a new instance of <see cref="MdLinkSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The link's text. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The link's target uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public static MdLinkSpan Link(string text, string uri) => new MdLinkSpan(text, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdLinkSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The link's text. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The link's target uri.</param>
        public static MdLinkSpan Link(string text, Uri uri) => new MdLinkSpan(text, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdLinkSpan"/>.        
        /// </summary>
        /// <param name="text">The link's text.</param>
        /// <param name="uri">The link's target uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public static MdLinkSpan Link(MdSpan text, string uri) => new MdLinkSpan(text, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdLinkSpan"/>.        
        /// </summary>
        /// <param name="text">The link's text.</param>
        /// <param name="uri">The link's target uri.</param>
        public static MdLinkSpan Link(MdSpan text, Uri uri) => new MdLinkSpan(text, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">
        /// The image's description. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The image's uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public static MdImageSpan Image(string description, string uri) => new MdImageSpan(description, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">
        /// The image's description. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The image's uri</param>
        public static MdImageSpan Image(string description, Uri uri) => new MdImageSpan(description, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">The image's description</param>
        /// <param name="uri">The image's uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public static MdImageSpan Image(MdSpan description, string uri) => new MdImageSpan(description, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">The image's description</param>
        /// <param name="uri">The image's uri</param>
        public static MdImageSpan Image(MdSpan description, Uri uri) => new MdImageSpan(description, uri);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The text to emphasize. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        public static MdEmphasisSpan Emphasis(string text) => new MdEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public static MdEmphasisSpan Emphasis(MdSpan text) => new MdEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public static MdEmphasisSpan Emphasis(MdCompositeSpan text) => new MdEmphasisSpan(text);


        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public static MdEmphasisSpan Emphasis(params MdSpan[] text) => new MdEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public static MdEmphasisSpan Emphasis(IEnumerable<MdSpan> text) => new MdEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">
        /// The text to emphasize. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <remarks><c>Italic()</c> is an alias for <c>Emphasis()</c></remarks>
        public static MdEmphasisSpan Italic(string text) => Emphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        /// <remarks><c>Italic()</c> is an alias for <c>Emphasis()</c></remarks>
        public static MdEmphasisSpan Italic(MdSpan text) => Emphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        /// <remarks><c>Italic()</c> is an alias for <c>Emphasis()</c></remarks>
        public static MdEmphasisSpan Italic(MdCompositeSpan text) => Emphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        /// <remarks><c>Italic()</c> is an alias for <c>Emphasis()</c></remarks>
        public static MdEmphasisSpan Italic(params MdSpan[] text) => Emphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        /// <remarks><c>Italic()</c> is an alias for <c>Emphasis()</c></remarks>
        public static MdEmphasisSpan Italic(IEnumerable<MdSpan> text) => Emphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/>.
        /// The specified text will be escaped.
        /// </summary>
        /// <param name="text">
        /// The text to emphasize. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        public static MdStrongEmphasisSpan StrongEmphasis(string text) => new MdStrongEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        public static MdStrongEmphasisSpan StrongEmphasis(MdSpan text) => new MdStrongEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        public static MdStrongEmphasisSpan StrongEmphasis(MdCompositeSpan text) => new MdStrongEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        public static MdStrongEmphasisSpan StrongEmphasis(params MdSpan[] text) => new MdStrongEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        public static MdStrongEmphasisSpan StrongEmphasis(IEnumerable<MdSpan> text) => new MdStrongEmphasisSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/>.
        /// The specified text will be escaped.
        /// </summary>
        /// <param name="text">
        /// The text to emphasize. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <remarks><c>Bold()</c> is an alias for <c>StrongEmphasis()</c></remarks>
        public static MdStrongEmphasisSpan Bold(string text) => StrongEmphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        /// <remarks><c>Bold()</c> is an alias for <c>StrongEmphasis()</c></remarks>
        public static MdStrongEmphasisSpan Bold(MdSpan text) => StrongEmphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        /// <remarks><c>Bold()</c> is an alias for <c>StrongEmphasis()</c></remarks>
        public static MdStrongEmphasisSpan Bold(MdCompositeSpan text) => StrongEmphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        /// <remarks><c>Bold()</c> is an alias for <c>StrongEmphasis()</c></remarks>
        public static MdStrongEmphasisSpan Bold(params MdSpan[] text) => StrongEmphasis(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize</param>
        /// <remarks><c>Bold()</c> is an alias for <c>StrongEmphasis()</c></remarks>
        public static MdStrongEmphasisSpan Bold(IEnumerable<MdSpan> text) => StrongEmphasis(text);


        /// <summary>
        /// Creates a new instance of <see cref="MdCodeSpan"/>
        /// </summary>
        /// <param name="text">The content of the code span. The value will not be escaped.</param>
        public static MdCodeSpan CodeSpan(string text) => new MdCodeSpan(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        /// <param name="spans">The spans to add to the composite span.</param>
        public static MdCompositeSpan CompositeSpan(params MdSpan[] spans) => new MdCompositeSpan(spans);

        /// <summary>
        /// Creates a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        /// <param name="spans">The spans to add to the composite span.</param>
        public static MdCompositeSpan CompositeSpan(IEnumerable<MdSpan> spans) => new MdCompositeSpan(spans);

        /// <summary>
        /// Creates a new instance of <see cref="MdRawMarkdownSpan"/>
        /// </summary>
        /// <param name="content">The span's content. The text will be written to the output without escaping.</param>
        public static MdRawMarkdownSpan RawMarkdown(string content) => new MdRawMarkdownSpan(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdTextSpan"/>
        /// </summary>
        /// <param name="text">The element's content. The value will be escaped before being written to the output.</param>
        public static MdTextSpan Text(string text) => new MdTextSpan(text);
    }
}
