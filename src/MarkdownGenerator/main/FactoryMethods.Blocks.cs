using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines static factory methods for blocks in markdown documents.
    /// When imported via "using static", this allows for more readable 
    /// construction of documents, e.g.
    /// <code>
    ///   new MdDocument(new MdParagraph("My content")) 
    /// </code>
    /// can be rewritten as
    /// <code>
    ///   Document(Paragraph("My Content"))
    /// </code>
    /// </summary>
    public static partial class FactoryMethods
    {
        public static MdDocument Document(MdContainerBlock root) => new MdDocument(root);

        public static MdDocument Document(params MdBlock[] content) => new MdDocument(Container(content));

        public static MdDocument Document(IEnumerable<MdBlock> content) => new MdDocument(Container(content));

        public static MdDocument Document(MdList list) => new MdDocument((MdBlock) list);

        public static MdDocument Document(MdBlockQuote blockQuote) => new MdDocument((MdBlock)blockQuote);


        public static MdContainerBlock Container(params MdBlock[] content) => new MdContainerBlock(content);

        public static MdContainerBlock Container(IEnumerable<MdBlock> content) => new MdContainerBlock(content);


        public static MdHeading Heading(string text, int level) => new MdHeading(text, level);

        public static MdHeading Heading(MdSpan text, int level) => new MdHeading(text, level);


        public static MdParagraph Paragraph(string text) => new MdParagraph(text);

        public static MdParagraph Paragraph(MdSpan text) => new MdParagraph(text);

        public static MdParagraph Paragraph(params MdSpan[] text) => new MdParagraph(text);


        public static MdCodeBlock CodeBlock(string text) => new MdCodeBlock(text, null);

        public static MdCodeBlock CodeBlock(string text, string infoString) => new MdCodeBlock(text, infoString);


        public static MdBulletList BulletList(params MdListItem[] items) => new MdBulletList(items);

        public static MdBulletList BulletList(IEnumerable<MdListItem> items) => new MdBulletList(items);


        public static MdOrderedList OrderedList(params MdListItem[] items) => new MdOrderedList(items);

        public static MdOrderedList OrderedList(IEnumerable<MdListItem> items) => new MdOrderedList(items);


        public static MdListItem ListItem(params MdBlock[] content) => new MdListItem(content);

        public static MdListItem ListItem(IEnumerable<MdBlock> content) => new MdListItem(content);

        public static MdListItem ListItem(string content) => new MdListItem(content);

        public static MdListItem ListItem(params MdSpan[] content) => new MdListItem(content);


        public static MdBlockQuote BlockQuote(params MdBlock[] content) => new MdBlockQuote(content);

        public static MdBlockQuote BlockQuote(IEnumerable<MdBlock> content) => new MdBlockQuote(content);

        public static MdBlockQuote BlockQuote(string content) => new MdBlockQuote(content);

        public static MdBlockQuote BlockQuote(params MdSpan[] content) => new MdBlockQuote(content);


        public static MdTable Table(MdTableRow headerRow, params MdTableRow[] rows) =>
            new MdTable(headerRow, rows);

        public static MdTable Table(MdTableRow headerRow, IEnumerable<MdTableRow> rows) =>
            new MdTable(headerRow, rows);


        public static MdTableRow Row(params string[] cells) => new MdTableRow(cells);

        public static MdTableRow Row(IEnumerable<string> cells) => new MdTableRow(cells);

        public static MdTableRow Row(params MdSpan[] cells) => new MdTableRow(cells);

        public static MdTableRow Row(IEnumerable<MdSpan> cells) => new MdTableRow(cells);


        public static MdThematicBreak ThematicBreak() => new MdThematicBreak();      

    }
}
