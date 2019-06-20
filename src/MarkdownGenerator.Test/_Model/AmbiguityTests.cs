using System.Collections.Generic;

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
        }

        public void Initialization_of_MdListItem_using_FactoryMethods()
        {
            _ = FactoryMethods.ListItem();

            _ = FactoryMethods.ListItem(FactoryMethods.Container());
            _ = FactoryMethods.ListItem(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.ListItem(FactoryMethods.ListItem());
            _ = FactoryMethods.ListItem(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.ListItem(FactoryMethods.BlockQuote());
            _ = FactoryMethods.ListItem(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());

            _ = FactoryMethods.ListItem(FactoryMethods.BulletList());
            _ = FactoryMethods.ListItem(FactoryMethods.OrderedList());
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
        }

        public void Initialization_of_MdContainerBlock_using_FactoryMethods()
        {
            _ = FactoryMethods.Container();

            _ = FactoryMethods.Container(FactoryMethods.Container());
            _ = FactoryMethods.Container(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.Container(FactoryMethods.ListItem());
            _ = FactoryMethods.Container(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.Container(FactoryMethods.BlockQuote());
            _ = FactoryMethods.Container(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());

            _ = FactoryMethods.Container(FactoryMethods.BulletList());
            _ = FactoryMethods.Container(FactoryMethods.OrderedList());
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
        }

        public void Initialization_of_MdBlockQuote_using_FactoryMethods()
        {
            _ = FactoryMethods.BlockQuote();

            _ = FactoryMethods.BlockQuote(FactoryMethods.Container());
            _ = FactoryMethods.BlockQuote(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.BlockQuote(FactoryMethods.ListItem());
            _ = FactoryMethods.BlockQuote(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.BlockQuote(FactoryMethods.BlockQuote());
            _ = FactoryMethods.BlockQuote(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());

            _ = FactoryMethods.BlockQuote(FactoryMethods.BulletList());
            _ = FactoryMethods.BlockQuote(FactoryMethods.OrderedList());
        }


        public void Initialization_of_MdEmphasisSpan_using_constructor()
        {
            _ = new MdEmphasisSpan(new MdCompositeSpan());
            _ = new MdEmphasisSpan(new MdTextSpan(""), new MdTextSpan(""));
            _ = new MdEmphasisSpan("", "");
            _ = new MdEmphasisSpan(new List<MdSpan>() { new MdTextSpan(""), new MdTextSpan("") });
        }

        public void Initialization_of_MdEmphasisSpan_using_FactoryMethods()
        {
            _ = FactoryMethods.Emphasis(FactoryMethods.CompositeSpan());
            _ = FactoryMethods.Emphasis(FactoryMethods.Text(""), FactoryMethods.Text(""));
            _ = FactoryMethods.Emphasis("", "");
            _ = FactoryMethods.Emphasis(new List<MdSpan>() { FactoryMethods.Text(""), FactoryMethods.Text("") });

            _ = FactoryMethods.Italic(FactoryMethods.CompositeSpan());
            _ = FactoryMethods.Italic(FactoryMethods.Text(""), FactoryMethods.Text(""));
            _ = FactoryMethods.Italic("", "");
            _ = FactoryMethods.Italic(new List<MdSpan>() { FactoryMethods.Text(""), FactoryMethods.Text("") });
        }


        public void Initialization_of_MdStrongEmphasisSpan_using_constructor()
        {
            _ = new MdStrongEmphasisSpan(new MdCompositeSpan());
            _ = new MdStrongEmphasisSpan(new MdTextSpan(""), new MdTextSpan(""));
            _ = new MdStrongEmphasisSpan("", "");
            _ = new MdStrongEmphasisSpan(new List<MdSpan>() { new MdTextSpan(""), new MdTextSpan("") });
        }

        public void Initialization_of_MdStrongEmphasisSpan_using_FactoryMethods()
        {
            _ = FactoryMethods.StrongEmphasis(FactoryMethods.CompositeSpan());
            _ = FactoryMethods.StrongEmphasis(FactoryMethods.Text(""), FactoryMethods.Text(""));
            _ = FactoryMethods.StrongEmphasis("", "");
            _ = FactoryMethods.StrongEmphasis(new List<MdSpan>() { FactoryMethods.Text(""), FactoryMethods.Text("") });

            _ = FactoryMethods.Bold(FactoryMethods.CompositeSpan());
            _ = FactoryMethods.Bold(FactoryMethods.Text(""), FactoryMethods.Text(""));
            _ = FactoryMethods.Bold("", "");
            _ = FactoryMethods.Bold(new List<MdSpan>() { FactoryMethods.Text(""), FactoryMethods.Text("") });
        }


        public void Initialization_of_MdTableRow_using_constructor()
        {
            _ = new MdTableRow();

            _ = new MdTableRow("Cell 1", "Cell2");
            _ = new MdTableRow(new MdTextSpan("Cell 1"), new MdTextSpan("Cell2"));
            _ = new MdTableRow(new[] { new MdTextSpan("Cell 1"), new MdTextSpan("Cell2") });
            _ = new MdTableRow(new MdCompositeSpan("Cell 1", "Cell 1 continued"));
        }

        public void Initialization_of_MdTableRow_using_FactoryMethods()
        {
            _ = FactoryMethods.Row();

            _ = FactoryMethods.Row("Cell 1", "Cell2");
            _ = FactoryMethods.Row(FactoryMethods.Text("Cell 1"), FactoryMethods.Text("Cell2"));
            _ = FactoryMethods.Row(new[] { FactoryMethods.Text("Cell 1"), FactoryMethods.Text("Cell2") });
            _ = FactoryMethods.Row(FactoryMethods.CompositeSpan("Cell 1", "Cell 1 continued"));
        }

    }
}
