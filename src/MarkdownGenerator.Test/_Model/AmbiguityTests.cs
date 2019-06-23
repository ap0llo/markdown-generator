using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Extensions;

namespace Grynwald.MarkdownGenerator.Test
{
    /// <summary>
    /// Sample code to ensure calls to constructors are not ambiguous
    /// </summary>
    /// <remarks>
    /// This is not really a test class, rather the test is if this code even compiles.
    /// <para>
    /// The implementations of <see cref="MdContainerBlockBase"/> all accept a <see cref="IEnumerable{MdBlock}"/>
    /// as constructor parameters. As some blocks also implement this interface,
    /// some constructor calls can get ambiguous (e.g. <c>new MdListItem(new MdContainerBlock)</c>.
    /// </para>
    /// <para>
    /// To work around this, additional constructors have to be defined in the implementations of <see cref="MdContainerBlockBase"/>.
    /// As long as this class compiles, constructor call are not ambiguous.
    /// </para>
    /// </remarks>
    public class AmbiguityTests
    {
        public void Initialization_of_MdDocument_using_constructor()
        {
            _ = new MdDocument();

            _ = new MdDocument(new MdContainerBlock());
            _ = new MdDocument(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdDocument(new MdListItem(), new MdListItem());

            _ = new MdDocument(new MdBlockQuote());
            _ = new MdDocument(new MdBlockQuote(), new MdBlockQuote());

            _ = new MdDocument(new MdBulletList());
            _ = new MdDocument(new MdOrderedList());

            _ = new MdDocument(new MdAdmonition("note"));
            _ = new MdDocument(new MdAdmonition("note"), new MdAdmonition("note"));
        }

        public void Initialization_of_MdListItem_using_constructor()
        {
            _ = new MdListItem();

            _ = new MdListItem(new MdContainerBlock());
            _ = new MdListItem(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdListItem(new MdListItem());
            _ = new MdListItem(new MdListItem(), new MdListItem());

            _ = new MdListItem(new MdBlockQuote());
            _ = new MdListItem(new MdBlockQuote(), new MdBlockQuote());

            _ = new MdListItem(new MdBulletList());
            _ = new MdListItem(new MdOrderedList());

            _ = new MdListItem(new MdAdmonition("note"));
        }

        public void Initialization_of_MdContainerBlock_using_constructor()
        {
            _ = new MdContainerBlock();

            _ = new MdContainerBlock(new MdContainerBlock());
            _ = new MdContainerBlock(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdContainerBlock(new MdListItem());
            _ = new MdContainerBlock(new MdListItem(), new MdListItem());

            _ = new MdContainerBlock(new MdBlockQuote());
            _ = new MdContainerBlock(new MdBlockQuote(), new MdBlockQuote());

            _ = new MdContainerBlock(new MdBulletList());
            _ = new MdContainerBlock(new MdOrderedList());

            _ = new MdContainerBlock(new MdAdmonition("note"));
            _ = new MdContainerBlock(new MdAdmonition("note"), new MdAdmonition("note"));
        }

        public void Initialization_of_MdBlockQuote_using_constructor()
        {
            _ = new MdBlockQuote();

            _ = new MdBlockQuote(new MdContainerBlock());
            _ = new MdBlockQuote(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdBlockQuote(new MdListItem());
            _ = new MdBlockQuote(new MdListItem(), new MdListItem());

            _ = new MdBlockQuote(new MdBlockQuote());
            _ = new MdBlockQuote(new MdBlockQuote(), new MdBlockQuote());

            _ = new MdBlockQuote(new MdBulletList());
            _ = new MdBlockQuote(new MdOrderedList());

            _ = new MdBlockQuote(new MdAdmonition("note"));
        }

        public void Initialization_of_MdEmphasisSpan_using_constructor()
        {
            _ = new MdEmphasisSpan(new MdCompositeSpan());
            _ = new MdEmphasisSpan(new MdTextSpan(""), new MdTextSpan(""));
            _ = new MdEmphasisSpan("", "");
            _ = new MdEmphasisSpan(new List<MdSpan>() { new MdTextSpan(""), new MdTextSpan("") });
        }

        public void Initialization_of_MdStrongEmphasisSpan_using_constructor()
        {
            _ = new MdStrongEmphasisSpan(new MdCompositeSpan());
            _ = new MdStrongEmphasisSpan(new MdTextSpan(""), new MdTextSpan(""));
            _ = new MdStrongEmphasisSpan("", "");
            _ = new MdStrongEmphasisSpan(new List<MdSpan>() { new MdTextSpan(""), new MdTextSpan("") });
        }

        public void Initialization_of_MdTableRow_using_constructor()
        {
            _ = new MdTableRow();

            _ = new MdTableRow("Cell 1", "Cell2");
            _ = new MdTableRow(new MdTextSpan("Cell 1"), new MdTextSpan("Cell2"));
            _ = new MdTableRow(new[] { new MdTextSpan("Cell 1"), new MdTextSpan("Cell2") });
            _ = new MdTableRow(new MdCompositeSpan("Cell 1", "Cell 1 continued"));
        }
    }
}
