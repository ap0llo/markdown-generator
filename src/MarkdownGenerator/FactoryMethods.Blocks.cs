using System;
using System.Collections.Generic;

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
        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified block as root element.
        /// </summary>
        /// <param name="root">The documents root block</param>
        public static MdDocument Document(MdContainerBlock root) => new MdDocument(root);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public static MdDocument Document(params MdBlock[] content) => new MdDocument(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// One or more blocks that make up the documents's content.
        /// The blocks will be wrapped in an instance of <see cref="MdContainerBlock"/> that will be the documents root block.
        /// </param>
        public static MdDocument Document(IEnumerable<MdBlock> content) => new MdDocument(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdList implements <see cref="IEnumerable{MdListItem}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public static MdDocument Document(MdList list) => new MdDocument(list);

        /// <summary>
        /// Creates a new instance of <see cref="MdDocument"/> with the specified content.
        /// </summary>
        /// <remarks>
        /// MdBlockQuote implements <see cref="IEnumerable{MdListItem}"/> so this constructor is necessary to prevent ambiguities.
        /// </remarks>
        public static MdDocument Document(MdBlockQuote blockQuote) => new MdDocument(blockQuote);

        /// <summary>
        /// Creates a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">The blocks the container blocks contains</param>
        public static MdContainerBlock Container(params MdBlock[] content) => new MdContainerBlock(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">The block to add to the container.</param>
        public static MdContainerBlock Container(MdContainerBlockBase content) => new MdContainerBlock(content);


        /// <summary>
        /// Creates a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">The blocks the container blocks contains</param>
        public static MdContainerBlock Container(IEnumerable<MdBlock> content) => new MdContainerBlock(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <param name="text">The text of the heading. Must not be null.</param>
        public static MdHeading Heading(int level, MdSpan text) => new MdHeading(level, text);

        /// <summary>
        /// Creates a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        /// <param name="text">The text of the heading. Must not be null.</param>
        public static MdHeading Heading(int level, params MdSpan[] text) => new MdHeading(level, text);

        /// <summary>
        /// Creates a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        public static MdHeading Heading(MdSpan text, int level) => new MdHeading(text, level);

        /// <summary>
        /// Creates a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="text">The paragraph's content</param>
        public static MdParagraph Paragraph(MdSpan text) => new MdParagraph(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="text">
        /// The paragraph's content. 
        /// The string value will implicitly be wrapped in an instance of <see cref="MdTextSpan"/>
        /// </param>
        /// <remarks>
        /// Although there is an implicit conversion from <see cref="String"/> to <see cref="MdSpan"/>
        /// the compiler does not seem to match the method in all situations,
        /// e.g. <c>new [] { "foo", "bar" }).Select(Paragraph)</c> so this overload is still necessary.
        /// </remarks>
        public static MdParagraph Paragraph(string text) => new MdParagraph(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="spans">
        /// One or more instances of <see cref="MdSpan"/>.
        /// As <see cref="MdParagraph"/> only supports a single span instance as text,
        /// the spans will be wrapped in an instance of <see cref="MdCompositeSpan"/>.
        /// </param>
        public static MdParagraph Paragraph(params MdSpan[] spans) => new MdParagraph(spans);

        /// <summary>
        /// Creates a new instance of <see cref="MdCodeBlock"/> with the specified text.
        /// </summary>
        /// <param name="text">The code blocks content</param>
        public static MdCodeBlock CodeBlock(string text) => new MdCodeBlock(text);

        /// <summary>
        /// Creates a new instance of <see cref="MdCodeBlock"/>.
        /// </summary>
        /// <param name="text">The code blocks content</param>
        /// <param name="infoString">
        /// The code blocks info string, typically used to indicate the language of the code block
        /// </param>
        public static MdCodeBlock CodeBlock(string text, string infoString) => new MdCodeBlock(text, infoString);

        /// <summary>
        /// Creates a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public static MdBulletList BulletList(params MdListItem[] listItems) => new MdBulletList(listItems);

        /// <summary>
        /// Creates a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public static MdBulletList BulletList(IEnumerable<MdListItem> listItems) => new MdBulletList(listItems);

        /// <summary>
        /// Creates a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public static MdOrderedList OrderedList(params MdListItem[] listItems) => new MdOrderedList(listItems);

        /// <summary>
        /// Creates a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public static MdOrderedList OrderedList(IEnumerable<MdListItem> listItems) => new MdOrderedList(listItems);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/>.
        /// </summary>
        public static MdListItem ListItem() => new MdListItem();


        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the content.
        /// </summary>
        /// <param name="content">The block to initially add to the list item.</param>
        public static MdListItem ListItem(MdContainerBlockBase content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public static MdListItem ListItem(params MdBlock[] content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the specified blocks.
        /// </summary>
        /// <param name="content">The blocks to initially add to the list item.</param>
        public static MdListItem ListItem(IEnumerable<MdBlock> content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the specified span
        /// </summary>
        /// <param name="content">
        /// The list item's content as a <see cref="MdSpan"/>. 
        /// The span will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public static MdListItem ListItem(MdSpan content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the specified span
        /// </summary>
        /// <param name="content">
        /// The list item's content as a <see cref="MdSpan"/>. 
        /// The span will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        /// <remarks>
        /// Although there is an implicit conversion from <see cref="String"/> to <see cref="MdSpan"/>
        /// the compiler does not seem to match the method in all situations,
        /// e.g. <c>new [] { "foo", "bar" }).Select(ListItem)</c> so this overload is still necessary.
        /// </remarks>
        public static MdListItem ListItem(string content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdListItem"/> containing the specified spans
        /// </summary>
        /// <param name="content">
        /// The list item's content as one or more instances of <see cref="MdSpan"/>. 
        /// The spans will implicitly be wrapped in a instance of see <see cref="MdParagraph"/>
        /// </param>
        public static MdListItem ListItem(params MdSpan[] content) => new MdListItem(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/>.
        /// </summary>
        public static MdBlockQuote BlockQuote() => new MdBlockQuote();

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content.
        /// </summary>
        /// <param name="content">The block to add to the block quote.</param>
        public static MdBlockQuote BlockQuote(MdContainerBlockBase content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">The content of the quote as one or more blocks (see <see cref="MdBlock"/>)</param>
        public static MdBlockQuote BlockQuote(params MdBlock[] content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">The content of the quote as one or more blocks (see <see cref="MdBlock"/>)</param>
        public static MdBlockQuote BlockQuote(IEnumerable<MdBlock> content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">
        /// The content of the quote as a span (see <see cref="MdSpan"/>.
        /// The span will automatically be wrapped in an instance of <see cref="MdParagraph"/>
        /// </param>
        public static MdBlockQuote BlockQuote(MdSpan content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">
        /// The content of the quote as a span (see <see cref="MdSpan"/>.
        /// The string will automatically be wrapped in an instance of <see cref="MdTextSpan"/> 
        /// which in turn will be wrapped in an instance of <see cref="MdParagraph"/>.
        /// This call is thus equivalent to <c>BlockQuote(Paragraph(Text(..))</c>
        /// </param>
        /// <remarks>
        /// Although there is an implicit conversion from <see cref="String"/> to <see cref="MdSpan"/>
        /// the compiler does not seem to match the method in all situations,
        /// e.g. <c>new [] { "foo", "bar" }).Select(BlockQuote)</c> so this overload is still necessary.
        /// </remarks>
        public static MdBlockQuote BlockQuote(string content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">
        /// The content of the quote as one or more spans (see <see cref="MdSpan"/>.
        /// The spans will automatically be wrapped in an instance of <see cref="MdParagraph"/>
        /// </param>
        public static MdBlockQuote BlockQuote(params MdSpan[] content) => new MdBlockQuote(content);

        /// <summary>
        /// Creates a new instance of <see cref="MdTable"/> with the specified content
        /// </summary>
        /// <param name="headerRow">The table's header row (not optional)</param>
        /// <param name="rows">The table's content rows</param>
        public static MdTable Table(MdTableRow headerRow, params MdTableRow[] rows) => new MdTable(headerRow, rows);

        /// <summary>
        /// Creates a new instance of <see cref="MdTable"/> with the specified content
        /// </summary>
        /// <param name="headerRow">The table's header row (not optional)</param>
        /// <param name="rows">The table's content rows</param>
        public static MdTable Table(MdTableRow headerRow, IEnumerable<MdTableRow> rows) => new MdTable(headerRow, rows);

        /// <summary>
        /// Creates a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">
        /// The rows's cells/columns.
        /// The string value will be wrapped into instances of <see cref="MdTextSpan"/> .
        /// </param>
        public static MdTableRow Row(IEnumerable<string> cells) => new MdTableRow(cells);

        /// <summary>
        /// Creates a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>
        public static MdTableRow Row(params MdSpan[] cells) => new MdTableRow(cells);

        /// <summary>
        /// Creates a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>#
        /// <remarks>
        /// Although there is an implicit conversion from <see cref="String"/> to <see cref="MdSpan"/>
        /// the compiler does not seem to match the method in all situations,
        /// so this overload is still necessary.
        /// </remarks>
        public static MdTableRow Row(params string[] cells) => new MdTableRow(cells);

        /// <summary>
        /// Creates a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>
        public static MdTableRow Row(IEnumerable<MdSpan> cells) => new MdTableRow(cells);
    
        /// <summary>
        /// Creates a new instance of <see cref="MdThematicBreak"/>
        /// </summary>
        public static MdThematicBreak ThematicBreak() => new MdThematicBreak();      
    }
}
